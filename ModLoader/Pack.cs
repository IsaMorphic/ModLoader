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

        public override Pack Fallback { get; set; }
        public override bool Enabled { get; set; } = true;

        public Pack(string name, HashSet<Module> modules) : base(name, modules)
        {
        }

        public Pack(string name, PackGroup parent) : base(name, new HashSet<Module>())
        {
            Parent = parent;

            string path = Path.Combine(Parent.BaseDirectory, "Mods", $"{name}.zip");
            Archive = new ZipArchive(File.OpenRead(path));

            foreach (var entry in Archive.Entries)
            {
                var ext = Path.GetExtension(entry.FullName);
                var fname = Path.GetFileNameWithoutExtension(entry.FullName);

                Module module;
                switch (ext.ToLower())
                {
                    default:
                        module = new Module(this, fname);
                        break;
                }

                Members.Add(module);
            }
        }
    }
}
