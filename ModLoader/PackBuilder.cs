using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

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

        public async Task BuildAsync()
        {
            ModuleGraph graph = new ModuleGraph();

            var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Path), $"{Name}.zip");

            using (var archiveStream = File.Create(path))
            using (var archive = new ZipArchive(archiveStream, ZipArchiveMode.Create))
            {
                foreach (var file in Directory.EnumerateFiles(Path, "*.*", SearchOption.AllDirectories))
                {

                    var name = file.Replace(Path, "").Trim('\\');
                    var entry = archive.CreateEntry(name);

                    using (var fileStream = File.OpenRead(file))
                    using (var entryStream = entry.Open())
                    {
                        await fileStream.CopyToAsync(entryStream);
                    }

                    graph.Table.Add(name, Guid.NewGuid());
                }

                using (var entryStream = archive.CreateEntry("_pack.png").Open())
                    await Task.Run(() => Bitmap.Save(entryStream, ImageFormat.Png));

                using (var entryStream = archive.CreateEntry("_pack.txt").Open())
                using (var writer = new StreamWriter(entryStream))
                    await writer.WriteAsync(Note);

                using (var entryStream = archive.CreateEntry("_pack.json").Open())
                    await graph.WriteToStreamAsync(entryStream);
            }
        }

        public static PackBuilder FromDirectory(string path)
        {
            return new PackBuilder(path);
        }
    }
}
