using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Abstract;
    using Exceptions;

    public class Chunk : Xunk<Chunk>
    {
        public override long Offset { get; }
        public override long Length => Data.Length - 1;

        public byte[] Data { get; }

        public Chunk(Patch parent, long offset, byte[] data) : base(parent)
        {
            Offset = offset;
            Data = data;
        }

        public override Chunk ResolveSelf() => this;

        public override string[] GetDisplayText()
        {
            List<string> lines = new List<string>();
            lines.Add($"Starting at offset 0x{Offset:X}:");
            lines.AddRange(Data
                .Select((n, idx) => new { idx, n })
                .GroupBy(x => x.idx / 8)
                .Select(g => g
                .Aggregate("", (acc, x) => $"{acc} {x.n:X2}"))
                .ToArray());
            return lines.ToArray();
        }

        public override string ToString()
        {
            return $"CHUNK;[offset:0x{Offset:X},length:{Length:X}]";
        }
    }

    public class Patch : XunkGroup<Chunk>
    {
        public class PatchLoader : IXunkGroupLoader<Chunk>
        {
            public async Task LoadAsync(XunkGroup<Chunk> group, CancellationToken token)
            {
                if (group.Root.Graph.Table[group.Name].Contains(group.Id)) return;

                var path = Path.Combine(group.Root.GamePath, group.Name);
                using (var stream = File.OpenWrite(path))
                {
                    foreach (var chunk in group.Members.Select(m => m.Resolve()))
                    {
                        stream.Seek(chunk.Offset, SeekOrigin.Begin);
                        await stream.WriteAsync(chunk.Data, 0, chunk.Data.Length);
                    }
                }

                group.Root.Graph.Table[group.Name].Add(group.Id);
            }
        }

        public Patch(Pack parent, string name, Guid id) : base(parent, name, id, new PatchLoader())
        {
        }

        public Task InitializeAsync()
        {
            return Task.Run(() =>
            {
                try
                {
                    using (var data = GetDataStream())
                    using (var reader = new BinaryReader(data))
                    {
                        while (true)
                        {
                            long offset = reader.ReadInt64();
                            byte[] bytes = reader.ReadBytes(reader.ReadInt32());

                            var chunk = new Chunk(this, offset, bytes);

                            Members.Add(chunk);
                        }
                    }
                }
                catch (EndOfStreamException) { }
            });
        }

        public override Stream GetDataStream()
        {
            return Parent.Archive.GetEntry($"{Name}.patch").Open();
        }
    }
}
