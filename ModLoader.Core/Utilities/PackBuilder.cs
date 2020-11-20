using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace ModLoader.Core.Utilities
{
    using Persistence;

    public class PackBuilder
    {
        private string InputDir { get; }
        private string OutputDir { get; }

        private string Name { get; }

        private Stream ImageStream { get; set; }
        private Pack.Meta MetaData { get; set; }

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

        public PackBuilder WithMetaData(Pack.Meta metaData)
        {
            if (MetaData != null)
                throw new InvalidOperationException("This value has already been specified");
            MetaData = metaData;
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

                    graph.Table.Add(name, Guid.NewGuid());
                }

                using (var entryStream = archive.CreateEntry("_pack.png").Open())
                {
                    ImageStream.Seek(0, SeekOrigin.Begin);
                    await ImageStream.CopyToAsync(entryStream);
                }

                using (var entryStream = archive.CreateEntry("_meta.json").Open())
                    await MetaData.WriteToStreamAsync(entryStream);

                using (var entryStream = archive.CreateEntry("_pack.json").Open())
                    await graph.WriteToStreamAsync(entryStream);
            }
        }
    }
}
