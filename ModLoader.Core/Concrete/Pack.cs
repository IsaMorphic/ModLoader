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
    using ModLoader.Core.Concrete;
    using Persistence;

    public class Pack : IGroup<Module>, ILoadable<Pack>
    {
        public Game Parent { get; }

        public ZipArchive Archive { get; private set; }

        public Graph Graph { get; private set; }

        public string Name { get; }

        public IResolvable<Pack> Fallback { get; set; }

        public bool Enabled { get; set; }

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
        }

        public Pack() : this(null, new HashSet<IResolvable<Module>>())
        {
        }

        public async Task InitializeAsync()
        {
            var path = Path.Combine(Parent.ModPath, $"{Name}.zip");
            Archive = new ZipArchive(File.OpenRead(path), ZipArchiveMode.Read);

            Graph = await Graph.LoadFromStreamAsync(Archive.GetEntry("_pack.json").Open());

            foreach (var entry in Archive.Entries.Where(entry => !entry.FullName.ToLowerInvariant().StartsWith("_pack") && !entry.FullName.ToLowerInvariant().EndsWith("/")))
            {
                string name = entry.FullName.ToLowerInvariant();
                Guid id = Graph.Table[name].Single();

                Module module;
                if (name.EndsWith(".diff"))
                    module = new Diff(this, name.Replace(".diff", ""), id);
                else if (name.EndsWith(".patch"))
                    module = new Patch(this, name.Replace(".patch", ""), id);
                else if (name.EndsWith(".burn"))
                    module = new Burn(this, name.Replace(".burn", ""), id);
                else
                    module = new Module(this, name, id);

                Members.Add(module);
            }
        }

        public Task UnloadAsync()
        {
            return Task.Run(Archive.Dispose);
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
