using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Abstract;
    using Newtonsoft.Json;
    using Persistence;

    public class Pack : IGroup<Module>, IGroup<Prioritized<Module>>, ILoadable<Pack>
    {
        public class Meta
        {
            public Guid Id { get; }
            public Guid? Fallback { get; }

            public string Name { get; }
            public string Author { get; }
            public string Notes { get; }

            public Meta(Guid id, Guid? fallback, string name, string author, string notes)
            {
                Id = id;
                Fallback = fallback;

                Name = name;
                Author = author;
                Notes = notes;
            }

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

        public HashSet<Module> Members { get; }
        IEnumerable<Module> IGroup<Module>.Members => Members;

        IEnumerable<Prioritized<Module>> IGroup<Prioritized<Module>>.Members => Members.Select(m => new PrioritizedModule(m, DependencyLevel));

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

            Members = new HashSet<Module>();

            Enabled = true;
        }

        public async Task InitializeAsync(int dependencyLevel = 0)
        {
            DependencyLevel = Math.Max(DependencyLevel, dependencyLevel);

            if (Initialized) return;

            var path = Path.Combine(Parent.ModPath, $"{Name}.zip");
            Archive = new ZipArchive(File.OpenRead(path), ZipArchiveMode.Read);

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

            if (Archive.GetEntry("_meta.json") != null)
            {
                using (var stream = Archive.GetEntry("_meta.json").Open())
                {
                    MetaData = await Meta.LoadFromStreamAsync(stream);
                }
            }
            else
            {
                MetaData = new Meta(Guid.NewGuid(), null, "meta placeholder", "meta placeholder", "meta placeholder");
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
                    Fallback = MetaData.Fallback == null ? Parent.BasePack : Parent.Packs.Single(p => p.Id == MetaData.Fallback);
                }

                await (Fallback as Pack).InitializeAsync(DependencyLevel + 1);
            }

            HashSet<string> burnDirs = new HashSet<string>();

            var entries = Archive.Entries.Where(entry => !entry.FullName.ToLowerInvariant().StartsWith("_pack") && !entry.FullName.ToLowerInvariant().StartsWith("_meta") && !entry.FullName.ToLowerInvariant().StartsWith("_fallback") && !entry.FullName.ToLowerInvariant().EndsWith("/"));
            foreach (var entry in entries)
            {
                string name = entry.FullName.ToLowerInvariant();
                Guid id = Graph.Table[name];

                if (name.EndsWith(".diff"))
                {
                    var diff = new Diff(this, name.Replace(".diff", ""), id);
                    await diff.InitializeAsync();
                    Members.Add(diff);
                }
                else if (name.EndsWith(".patch"))
                {
                    var patch = new Patch(this, name.Replace(".patch", ""), id);
                    await patch.InitializeAsync();
                    Members.Add(patch);
                }
                else if (Path.GetFileName(name) == ".burn")
                {
                    var dir = Path.GetDirectoryName(name);
                    burnDirs.Add(dir);
                }
                else if (name.EndsWith(".burn"))
                {
                    var burn = new Burn(this, name.Replace(".burn", ""), id);
                    Members.Add(burn);
                }
                else
                {
                    var module = new Module(this, name, id);
                    Members.Add(module);
                }
            }

            foreach (var dir in burnDirs)
            {
                var toBurn = Parent.BasePack.Members
                        .Select(m => m.Resolve().Name)
                        .Where(n => n.StartsWith(dir) && !Members.Any(m => m.Resolve().Name == n))
                        .Select(n => new Burn(this, n, Guid.NewGuid()));
                Members.UnionWith(toBurn);
            }

            Initialized = true;
        }

        public void Unload()
        {
            Archive?.Dispose();
        }

        public void Reload()
        {
            var path = Path.Combine(Parent.ModPath, $"{Name}.zip");
            Archive = new ZipArchive(File.OpenRead(path), ZipArchiveMode.Read);
        }

        public Pack ResolveSelf() => this;

        public async Task LoadSelfAsync()
        {
            foreach (var module in Members)
            {
                await module.Resolve()?.LoadAsync();
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
