using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Abstract;
    using Persistence;

    public class Pack : IGroup<Module>, IGroup<Prioritized<Module, string>>, ILoadable<Pack>
    {
        public class Meta
        {
            public Guid Id { get; set; }
            public Guid? Fallback { get; set; }

            public string Name { get; set; }
            public string Author { get; set; }
            public string Notes { get; set; }

            public async Task WriteToStreamAsync(Stream stream)
            {
                using (var writer = new StreamWriter(stream))
                    await writer.WriteAsync(JsonConvert.SerializeObject(this));
            }

            public static async Task<Meta> LoadFromStreamAsync(Stream stream)
            {
                using (var reader = new StreamReader(stream))
                    return JsonConvert.DeserializeObject<Meta>(await reader.ReadToEndAsync());
            }
        }

        public Game Parent { get; }

        public string Name { get; }

        public Guid Id => MetaData.Id;

        public Meta MetaData { get; private set; }

        public Dictionary<string, Module> Members { get; }
        IEnumerable<Module> IGroup<Module>.Members => Members.Values;

        IEnumerable<Prioritized<Module, string>> IGroup<Prioritized<Module, string>>.Members => Members.Values.Select(m => new PrioritizedModule(m, DependencyLevel));

        public Graph Graph { get; private set; }

        public ZipArchive Archive { get; private set; }

        public IResolvable<Pack> Fallback { get; private set; }

        private bool _enabled;
        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (Initialized && _enabled != value)
                {
                    if (value)
                        Reload();
                    else
                        Unload();
                }
                _enabled = value;
            }
        }

        public bool Initialized { get; private set; }
        public int DependencyLevel { get; private set; }

        public Pack(Game parent, string name)
        {
            Name = name;
            Parent = parent;

            Members = new Dictionary<string, Module>();

            Enabled = true;
        }

        public async Task ReadMetaDataAsync()
        {
            if (Initialized) return;

            var path = Path.Combine(Parent.ModPath, $"{Name}.zip");
            Archive = new ZipArchive(File.OpenRead(path), ZipArchiveMode.Read);

            if (Archive.GetEntry("_meta.json") != null)
            {
                using (var stream = Archive.GetEntry("_meta.json").Open())
                {
                    MetaData = await Meta.LoadFromStreamAsync(stream);
                }
            }
            else
            {
                MetaData = new Meta
                {
                    Id = Guid.NewGuid(),
                    Fallback = null,
                    Name = null,
                    Author = null,
                    Notes = "This pack is missing its _meta.json file. Please update this pack to add some."
                };
            }
        }

        public async Task InitializeAsync(int dependencyLevel = 0)
        {
            DependencyLevel = Math.Max(DependencyLevel, dependencyLevel);

            if (Initialized) return;

            if (MetaData == null)
            {
                await ReadMetaDataAsync();
            }

            try
            {
                using (var stream = Archive.GetEntry("_pack.json").Open())
                {
                    Graph = await Graph.LoadFromStreamAsync(stream);
                }
            }
            catch
            {
                using (var stream = Archive.GetEntry("_pack.json").Open())
                {
                    Graph = new Graph(await GraphCompat.LoadFromStreamAsync(stream));
                }
            }

            var noteEntry = Archive.GetEntry("_pack.txt");
            if (noteEntry != null)
            {
                using (var stream = noteEntry.Open())
                using (var reader = new StreamReader(stream))
                {
                    MetaData.Notes = await reader.ReadToEndAsync();
                }
            }

            if (this != Parent.BasePack)
            {
                var fallbackEntry = Archive.GetEntry("_fallback.txt");
                if (fallbackEntry != null)
                {
                    string fallback;

                    using (var stream = fallbackEntry.Open())
                    using (var reader = new StreamReader(stream))
                        fallback = (await reader.ReadLineAsync()).ToLowerInvariant();

                    Fallback = Parent.Packs.SingleOrDefault(p => p.Name == fallback) ?? Parent.BasePack;
                }
                else
                {
                    Fallback = MetaData.Fallback == null ? Parent.BasePack : Parent.Packs.SingleOrDefault(p => p.Id == MetaData.Fallback);
                    if (Fallback == null) throw new InvalidOperationException($"{this} is missing a dependency.");
                }

                await (Fallback as Pack).InitializeAsync(DependencyLevel + 1);

                MetaData.Fallback = (Fallback as Pack).Id;
            }

            HashSet<string> burnDirs = new HashSet<string>();

            var entries = Archive.Entries.Where(entry => !entry.FullName.ToLowerInvariant().StartsWith("_pack") && !entry.FullName.ToLowerInvariant().StartsWith("_meta") && !entry.FullName.ToLowerInvariant().StartsWith("_fallback") && !entry.FullName.ToLowerInvariant().EndsWith("/"));
            foreach (var entry in entries)
            {
                string name = entry.FullName.ToLowerInvariant();
                Guid id = Graph.Table[name];

                if (name.EndsWith(".diff"))
                {
                    var key = name.Replace(".diff", "");
                    var diff = new Diff(this, key, id);
                    await diff.InitializeAsync();
                    Members.Add(key, diff);
                }
                else if (name.EndsWith(".patch"))
                {
                    var key = name.Replace(".patch", "");
                    var patch = new Patch(this, key, id);
                    await patch.InitializeAsync();
                    Members.Add(key, patch);
                }
                else if (Path.GetFileName(name) == ".burn")
                {
                    var dir = Path.GetDirectoryName(name);
                    burnDirs.Add(dir);
                }
                else if (name.EndsWith(".burn"))
                {
                    var key = name.Replace(".burn", "");
                    var burn = new Burn(this, key, id);
                    Members.Add(key, burn);
                }
                else
                {
                    var module = new Module(this, name, id);
                    Members.Add(name, module);
                }
            }

            foreach (var dir in burnDirs)
            {
                var namesToBurn = Parent.BasePack.Members.Keys
                    .Where(n => n.StartsWith(dir) && !Members.ContainsKey(n));

                foreach (var name in namesToBurn)
                {
                    Members.Add(name, new Burn(this, name, Guid.NewGuid()));
                }
            }

            Initialized = true;
        }

        public void Unload()
        {
            Archive?.Dispose();
            Archive = null;
        }

        public void Reload()
        {
            var path = Path.Combine(Parent.ModPath, $"{Name}.zip");
            Archive = new ZipArchive(File.OpenRead(path), ZipArchiveMode.Read);
        }

        public Pack ResolveSelf() => this;

        public async Task LoadSelfAsync()
        {
            foreach (var module in Members.Values)
            {
                await module.Resolve()?.LoadAsync();
            }
        }

        public override string ToString()
        {
            return MetaData.Name ?? Name;
        }
    }
}
