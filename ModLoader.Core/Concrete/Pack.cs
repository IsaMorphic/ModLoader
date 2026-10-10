using System.IO.Compression;

namespace ModLoader.Core
{
    using Abstract;
    using Persistence.Mutable;

    public partial class Pack : IPackBase, IResolvable<Pack>, IGroup<Prioritized<Module, string>>
    {
        private ZipArchive _archive;

        public Game Parent { get; }

        public string Name { get; }

        public Guid Id => MetaData.Id;

        public Meta MetaData { get; private set; }

        public IDictionary<string, Module> Members { get; }
        IEnumerable<Module> IGroup<Module>.Members => Members.Values;

        IEnumerable<Prioritized<Module, string>> IGroup<Prioritized<Module, string>>.Members => Members.Values.Select(m => new PrioritizedModule(m));

        public Graph Graph { get; private set; }

        public IResolvable<IPackBase> Fallback { get; private set; }
        IResolvable<Pack> IResolvable<Pack>.Fallback => Fallback as IResolvable<Pack>;

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

        public bool IsArchive { get; private set; }

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
            if (File.Exists(path))
            {
                _archive = new ZipArchive(File.OpenRead(path), ZipArchiveMode.Read);
                IsArchive = true;
            }

            if (GetStream("_meta.snab") is Stream metaStream)
            {
                MetaData = await Meta.LoadFromStreamAsync(metaStream);
            }
            else if (GetStream("_meta.json") is Stream jsonStream)
            {
                MetaData = await Meta.LoadFromStreamAsync(jsonStream, useJson: true);
            }
            else
            {
                MetaData = new Meta
                {
                    Id = Guid.NewGuid(),
                    Fallback = null,
                    Name = null,
                    Author = null,
                    Notes = "This pack is missing its _meta.snab file. Please update this pack to add some."
                };
            }
        }

        public async Task InitializeAsync()
        {
            if (Initialized) return;

            if (MetaData == null)
            {
                await ReadMetaDataAsync();
            }

            if (GetStream("_pack.snab") is Stream snabStream)
            {
                Graph = await Graph.LoadFromStreamAsync(snabStream);
            }
            else if (GetStream("_pack.json") is Stream jsonStream)
            {
                Graph = await Graph.LoadFromStreamAsync(jsonStream, useJson: true);
            }

            var noteStream = GetStream("_pack.txt");
            if (noteStream != null)
            {
                using (var reader = new StreamReader(noteStream))
                {
                    MetaData.Notes = await reader.ReadToEndAsync();
                }
            }

            var fallbackStream = GetStream("_fallback.txt");
            if (fallbackStream != null)
            {
                string fallback;

                using (var reader = new StreamReader(fallbackStream))
                    fallback = (await reader.ReadLineAsync()).ToLowerInvariant();

                Fallback = Parent.Packs.SingleOrDefault(p => p.Name == fallback) as IPackBase ?? Parent.BasePack;
            }
            else
            {
                Fallback = MetaData.Fallback == null ? Parent.BasePack : Parent.Packs.SingleOrDefault(p => p.Id == MetaData.Fallback);
                if (Fallback == null) throw new InvalidOperationException($"{this} is missing a dependency.");
            }

            await (Fallback as IPackBase).InitializeAsync();

            MetaData.Fallback = (Fallback as IPackBase).Id;

            HashSet<string> burnDirs = new HashSet<string>();

            IEnumerable<string> entries;
            if (_archive == null)
            {
                entries = Directory.EnumerateFiles(Path.Combine(Parent.ModPath, Name + ".pack"), "*", SearchOption.AllDirectories)
                    .Select(f => Path.GetRelativePath(Path.Combine(Parent.ModPath, Name + ".pack"), f).ToLowerInvariant());
            }
            else
            {
                entries = _archive.Entries.Select(entry => entry.FullName.ToLowerInvariant());
            }

            foreach (var entry in entries.Where(entry => !entry.StartsWith("_pack") && !entry.StartsWith("_meta") && !entry.StartsWith("_fallback") && !entry.EndsWith("\\")))
            {
                Guid id = Graph.Table[entry];

                if (entry.EndsWith(".diff"))
                {
                    var key = entry.Replace(".diff", "");
                    var diff = new Diff(this, key, id);
                    await diff.InitializeAsync();
                    Members.Add(key, diff);
                }
                else if (entry.EndsWith(".patch"))
                {
                    var key = entry.Replace(".patch", "");
                    var patch = new Patch(this, key, id);
                    await patch.InitializeAsync();
                    Members.Add(key, patch);
                }
                else if (Path.GetFileName(entry) == ".burn")
                {
                    var dir = Path.GetDirectoryName(entry);
                    burnDirs.Add(dir);
                }
                else if (entry.EndsWith(".burn"))
                {
                    var key = entry.Replace(".burn", "");
                    var burn = new Burn(this, key, id);
                    Members.Add(key, burn);
                }
                else
                {
                    var module = new Module(this, entry, id);
                    Members.Add(entry, module);
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
            _archive?.Dispose();
            _archive = null;
        }

        public void Reload()
        {
            var path = Path.Combine(Parent.ModPath, $"{Name}.zip");
            if (File.Exists(path))
            {
                _archive?.Dispose();
                _archive = new ZipArchive(File.OpenRead(path), ZipArchiveMode.Read);
            }
        }

        Pack IPotential<Pack>.ResolveSelf() => this;

        public IPackBase ResolveSelf() => this;

        public async Task LoadSelfAsync()
        {
            foreach (var module in Members.Values)
            {
                await module.Resolve()?.LoadAsync();
            }
        }

        public Stream GetStream(string name)
        {
            if (_archive == null)
            {
                try
                {
                    string filePath = Path.Combine(Parent.ModPath, Name + ".pack", name);
                    return File.OpenRead(filePath);
                }
                catch (FileNotFoundException)
                {
                    return null;
                }
            }
            else 
            {
                return _archive.GetEntry(name)?.Open();
            }
        }

        public override string ToString()
        {
            return MetaData.Name ?? Name;
        }
    }
}
