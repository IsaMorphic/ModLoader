using CFS.SnabNet;

namespace ModLoader.Core
{
    using Abstract;
    using Exceptions;

    public partial class Chunk : Xunk<Chunk>, IExceptional
    {
        [SnabStruct]
        public partial class Data
        {
            [SnabField]
            public long Offset { get; set; }

            [SnabField("Buffer", SnabType.Buffer)]
            public byte[] Buffer { get; set; }
        }

        private readonly Data _data;

        public override long Offset => _data.Offset;
        public override long Length => _data.Buffer.Length - 1;

        public byte[] Buffer => _data.Buffer;

        public HashSet<Exception> Errors { get; }

        public Chunk(Patch parent, Data data) : base(parent)
        {
            _data = data;
            Errors = new();
        }

        public override Chunk ResolveSelf() => this;

        public override string[] GetDisplayText()
        {
            List<string> lines = new List<string>();
            lines.Add($"Starting at offset 0x{Offset:X}:");
            lines.AddRange(_data.Buffer
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

    public partial class Patch : XunkGroup<Chunk>
    {
        public class PatchLoader : IXunkLoader<Chunk>
        {
            public async Task LoadAsync(XunkGroup<Chunk> group)
            {
                if (group.Root.Graph.Table.ContainsKey(group.Name) && group.Root.Graph.Table[group.Name] == group.Id) return;

                await group.Root.BasePack.CopyModuleAsync(group.Name);

                var file = await group.Root.Files.StageFileAsync(group.Name);

                await group.Base.GetDataStream().CopyToAsync(file.Stream);

                try
                {
                    foreach (var chunk in group.Xunks.Select(m => m.ResolveSelf()))
                    {
                        if (chunk.Offset > file.Stream.Length)
                            throw new InvalidOperationException($"An attempt was made by a patch module to modify data outside of the base module's bounds.\nOffending module: {group.Name}");
                        file.Stream.Seek(chunk.Offset, SeekOrigin.Begin);
                        await file.Stream.WriteAsync(chunk.Buffer, 0, chunk.Buffer.Length);
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

        [SnabStruct]
        public partial class Data
        {
            [SnabField("Chunks", SnabType.Array)]
            public Chunk.Data[] Chunks { get; set; }
        }

        static Patch()
        {
            XunkLoader.Register(new PatchLoader());
        }

        public Patch(Pack parent, string name, Guid id) : base(parent, name, id)
        {
        }

        public Task InitializeAsync()
        {
            return Task.Run(async () =>
            {
                await Root.BasePack.CopyModuleAsync(Name);

                try
                {
                    SnabInstance instance = new();

                    using (var stream = GetDataStream())
                    using (var memStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memStream);
                        memStream.Position = 0;

                        using (var reader = instance.CreateReader(memStream))
                        {
                            Chunk.Data[] chunks = reader.Deserialize<Data>().Chunks;
                            foreach (var chunkData in chunks)
                            {
                                var chunk = new Chunk(this, chunkData);
                                if (Xunks.Select(c => c.ResolveSelf().MergeKey).Contains(chunk.MergeKey))
                                    chunk.Errors.Add(new ConflictException<Chunk>($"This chunk conflicts with a chunk in this patch that was parsed prior.\nOffending module: {this}"));
                                Xunks.Add(chunk);
                            }
                        }
                    }
                }
                catch (EndOfStreamException)
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

                                var chunk = new Chunk(this, new Chunk.Data() { Offset = offset, Buffer = bytes });

                                if (Xunks.Select(c => c.ResolveSelf().MergeKey).Contains(chunk.MergeKey))
                                    chunk.Errors.Add(new ConflictException<Chunk>($"This chunk conflicts with a chunk in this patch that was parsed prior.\nOffending module: {this}"));

                                Xunks.Add(chunk);
                            }
                        }
                    }
                    catch (EndOfStreamException) { }
                }
            });
        }

        public override Stream GetDataStream()
        {
            return Parent.GetStream($"{Name}.patch");
        }
    }
}
