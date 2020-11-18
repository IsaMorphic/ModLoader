using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Abstract;
    using Persistence;

    public class Pack : IGroup<IResolvable<Module>>, ILoadable<Pack>
    {
        public Game Parent { get; }

        public ZipArchive Archive { get; private set; }

        public Graph Graph { get; private set; }

        public string Name { get; }

        public IResolvable<Pack> Fallback { get; set; }

        private bool _initialized { get; set; }

        private bool _enabled;
        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (_initialized && _enabled != value)
                {
                    if (value)
                        Reload();
                    else
                        Unload();
                }
                _enabled = value;
            }
        }

        public HashSet<IResolvable<Module>> Members { get; }

        public Pack(string name, HashSet<IResolvable<Module>> modules)
        {
            Name = name;
            Members = modules;

            Enabled = true;
        }

        public Pack(Game parent, string name) : this(name, new HashSet<IResolvable<Module>>())
        {
            Parent = parent;
            Fallback = Parent.BasePack;
        }

        public Pack() : this(null, new HashSet<IResolvable<Module>>())
        {
        }

        public async Task InitializeAsync()
        {
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

            HashSet<string> burnDirs = new HashSet<string>();

            var entries = Archive.Entries.Where(entry => !entry.FullName.ToLowerInvariant().StartsWith("_pack") && !entry.FullName.ToLowerInvariant().EndsWith("/"));
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

            _initialized = true;
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

        public async Task LoadSelfAsync(CancellationToken token)
        {
            foreach (var module in Members)
            {
                await module.Resolve()?.LoadAsync(token);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
