using ModLoader.Core.Persistence;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace ModLoader.Core.Utilities
{
    public class PackBuilder
    {
        private string Path { get; }

        private Image Image { get; set; }
        private string Note { get; set; }

        private string Name { get; set; }

        private PackBuilder(string path)
        {
            Path = path;
        }

        public PackBuilder WithBitmap(Image image)
        {
            Image = image;
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
            Graph graph = new Graph();

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

                    graph.Table.Add(name, new HashSet<Guid> { Guid.NewGuid() });
                }

                using (var entryStream = archive.CreateEntry("_pack.png").Open())
                    await Image.SaveAsPngAsync(entryStream);

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
