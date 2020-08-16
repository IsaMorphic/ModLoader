using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader
{
    public class Pack : Group<Pack, Module>
    {
        public PackGroup Parent { get; }

        public ZipArchive Archive { get; private set; }

        public ModuleGraph Graph { get; private set; }

        public Pack() : base("_none_", new HashSet<Unit<Module>>())
        {
        }

        public Pack(string name, PackGroup parent) : base(name, new HashSet<Unit<Module>>())
        {
            Parent = parent;
        }

        public async Task InitializeAsync()
        {
            var path = Path.Combine(Parent.ModPath, $"{Name}.zip");
            Archive = new ZipArchive(File.OpenRead(path), ZipArchiveMode.Read);

            Graph = await ModuleGraph.LoadFromStreamAsync(Archive.GetEntry("_pack.json").Open());

            foreach (var entry in Archive.Entries.Where(entry => !entry.FullName.StartsWith("_pack") && !entry.FullName.EndsWith("/")))
            {
                var module = new Module(entry.FullName, Graph.Table[entry.FullName], this);
                await module.InitializeAsync();

                Members.Add(module);
            }
        }

        protected override Pack ResolveSelf() => this;
    }
}
