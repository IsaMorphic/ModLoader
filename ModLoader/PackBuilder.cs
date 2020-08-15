using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;

namespace ModLoader
{
    public class PackBuilder
    {
        private string Path { get; }

        private Bitmap Bitmap { get; set; }
        private string Note { get; set; }

        private string Name { get; set; }

        private PackBuilder(string path)
        {
            Path = path;
        }

        public PackBuilder WithBitmap(Bitmap bitmap)
        {
            Bitmap = bitmap;
            return this;
        }

        public PackBuilder WithNote(string note)
        {
            Note = note;
            return this;
        }


        public PackBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public void Build()
        {
            ModuleGraph graph = new ModuleGraph();

            var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Path), $"{Name}.zip");

            using (var archiveStream = File.Create(path))
            using (var archive = new ZipArchive(archiveStream, ZipArchiveMode.Create))
            {
                foreach (var file in Directory.EnumerateFiles(Path, "*.*", SearchOption.AllDirectories))
                {
                    var name = file.Replace(Path, "").Trim('\\');
                    archive.CreateEntryFromFile(file, name);

                    graph.Table.Add(name, Guid.NewGuid());
                }

                using (var entryStream = archive.CreateEntry("_pack.png").Open())
                    Bitmap.Save(entryStream, ImageFormat.Png);

                using (var entryStream = archive.CreateEntry("_pack.txt").Open())
                using (var writer = new StreamWriter(entryStream))
                    writer.Write(Note);

                using (var entryStream = archive.CreateEntry("_pack.json").Open())
                    graph.WriteToStream(entryStream);
            }
        }

        public static PackBuilder FromDirectory(string path)
        {
            return new PackBuilder(path);
        }
    }
}
