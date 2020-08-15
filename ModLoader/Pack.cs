using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace ModLoader
{
    public class Pack : Group<Pack, Module>
    {
        public PackGroup Parent { get; }

        public ZipArchive Archive { get; }

        public ModuleGraph Graph { get; }

        public Pack() : base("_none_", new HashSet<Unit<Module>>())
        {
        }

        public Pack(string name, PackGroup parent) : base(name, new HashSet<Unit<Module>>())
        {
            Parent = parent;

            Fallback = Parent.BasePack;

            var path = Path.Combine(Parent.ModPath, $"{Name}.zip");
            Archive = new ZipArchive(File.OpenRead(path));

            Graph = ModuleGraph.LoadFromStream(Archive.GetEntry("_pack.json").Open());

            foreach (var entry in Archive.Entries.Where(entry => !entry.FullName.StartsWith("_pack") && !entry.FullName.EndsWith("/")))
            {
                var module = new Module(entry.FullName, Graph.Table[entry.FullName], this);
                Members.Add(module);
            }
        }

        protected override Pack ResolveSelf() => this;
    }
}
