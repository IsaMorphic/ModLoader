using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Abstract;

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
        public class PatchLoader : IXunkLoader<Chunk>
        {
            public async Task LoadAsync(XunkGroup<Chunk> group)
            {
                if (group.Base == null)
                    throw new InvalidOperationException($"Attempted to load a patch with an unresolved base.\nOffending Pack: {group.Parent}");

                if (group.Root.Graph.Table.ContainsKey(group.Name) && group.Root.Graph.Table[group.Name] == group.Id) return;

                var file = await group.Root.Files.StageFileAsync(group.Name);

                await group.Base.GetDataStream().CopyToAsync(file.Stream);

                try
                {
                    foreach (var chunk in group.Xunks.Select(m => m.ResolveSelf()))
                    {
                        if (chunk.Offset > file.Stream.Length)
                            throw new InvalidOperationException($"An attempt was made by a patch module to modify data outside of the base module's bounds.\nOffending module: {group.Name}");
                        file.Stream.Seek(chunk.Offset, SeekOrigin.Begin);
                        await file.Stream.WriteAsync(chunk.Data, 0, chunk.Data.Length);
                    }

                    await group.Root.Files.CommitFileAsync(file);

                    if (group.Root.Graph.Table.ContainsKey(group.Name))
                        group.Root.Graph.Table[group.Name] = group.Id;
                    else
                        group.Root.Graph.Table.Add(group.Name, group.Id);
                }
                catch (Exception)
                {
                    await group.Root.Files.UnstageFileAsync(file);
                    throw;
                }
            }
        }

        static Patch()
        {
            XunkLoader.Loaders.Add(typeof(Chunk), new PatchLoader());
        }

        public Patch(Pack parent, string name, Guid id) : base(parent, name, id)
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

                            Xunks.Add(chunk);
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
