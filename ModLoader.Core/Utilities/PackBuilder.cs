using ModLoader.Core.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace ModLoader.Core.Utilities
{
    public class PackBuilder
    {
        private string InputDir { get; }
        private string OutputDir { get; }

        private string Name { get; }

        private Stream ImageStream { get; set; }
        private string Note { get; set; }

        public PackBuilder(string inputDir, string outputDir, string name)
        {
            InputDir = inputDir;
            OutputDir = outputDir;

            Name = name;
        }

        public PackBuilder(string inputDir, string name)
        {
            InputDir = inputDir;
            OutputDir = Path.GetDirectoryName(InputDir);

            Name = name;
        }

        public PackBuilder WithImageStream(Stream imageStream)
        {
            if (ImageStream != null)
                throw new InvalidOperationException("This value has already been specified");
            ImageStream = imageStream;
            return this;
        }

        public PackBuilder WithNote(string note)
        {
            if (Note != null)
                throw new InvalidOperationException("This value has already been specified");
            Note = note;
            return this;
        }

        public async Task BuildAsync()
        {
            Graph graph = new Graph();

            Directory.CreateDirectory(OutputDir);

            using (var archiveStream = File.Create(Path.Combine(OutputDir, $"{Name}.zip")))
            using (var archive = new ZipArchive(archiveStream, ZipArchiveMode.Create))
            {
                foreach (var file in Directory.EnumerateFiles(InputDir, "*.*", SearchOption.AllDirectories))
                {
                    var name = file.Replace(InputDir, "").Trim('\\').ToLowerInvariant();
                    var entry = archive.CreateEntry(name);

                    using (var fileStream = File.OpenRead(file))
                    using (var entryStream = entry.Open())
                    {
                        await fileStream.CopyToAsync(entryStream);
                    }

                    graph.Table.Add(name, new HashSet<Guid> { Guid.NewGuid() });
                }

                using (var entryStream = archive.CreateEntry("_pack.png").Open())
                {
                    ImageStream.Seek(0, SeekOrigin.Begin);
                    await ImageStream.CopyToAsync(entryStream);
                }

                using (var entryStream = archive.CreateEntry("_pack.txt").Open())
                using (var writer = new StreamWriter(entryStream))
                    await writer.WriteAsync(Note);

                using (var entryStream = archive.CreateEntry("_pack.json").Open())
                    await graph.WriteToStreamAsync(entryStream);
            }
        }
    }
}
