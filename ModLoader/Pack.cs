using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace ModLoader
{
    public class Pack : Unit
    {
        public new PackList Parent => base.Parent as PackList;

        public Pack(PackList parent, string name) : base(parent, name)
        {
            string path = Path.Combine(parent.BaseDirectory, "Mods", $"{name}.zip");
            Archive = new ZipArchive(File.OpenRead(path));

            foreach (var entry in Archive.Entries)
            {
                var ext = Path.GetExtension(entry.FullName);
                var fname = Path.GetFileNameWithoutExtension(entry.FullName);

                Module module;
                switch (ext.ToLower())
                {
                    case "patch":
                        module = new Patch(this, fname);
                        break;
                    case "diff":
                        module = null; // Placeholder
                        break;
                    default:
                        module = new Replacement(this, fname);
                        break;
                }

                Modules.Add(module.Name, module);
            }
        }

        public ZipArchive Archive { get; }

        public Dictionary<string, Module> Modules { get; }

        public override Task Load()
        {
            throw new NotImplementedException();
        }
    }
}
