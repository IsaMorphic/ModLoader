using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Abstract;
    using Filters;
    using Exceptions;

    public class Chunk : IMergeable<Chunk>
    {
        public IResolvable<Chunk> Fallback => null;
        public bool Enabled { get; set; }

        public long Offset { get; }
        public byte[] Data { get; }

        public Chunk(long offset, byte[] data)
        {
            Offset = offset;
            Data = data;

            Enabled = true;
        }

        public bool CanMergeWith(Chunk other)
        {
            return Offset >= other.Offset && other.Offset + other.Data.Length >= Offset;
        }

        public IResolvable<Chunk> MergeWith(HashSet<Chunk> others)
        {
            return new Conflict<Chunk>(this, others);
        }

        public Chunk ResolveSelf() => this;
    }

    public class ResolvingPatch : Patch
    {
        public IResolvable<IGroup<Chunk>> Resolver { get; }

        public ResolvingPatch(Pack parent, string name, IResolvable<IGroup<Chunk>> resolver) : base(parent, name, Guid.Empty)
        {
            Resolver = resolver;
        }

        public override Module ResolveSelf()
        {
            return new Patch(Parent, Name, Resolver.Resolve().Members);
        }

        public override string ToString()
        {
            return "(MERGED PATCH)";
        }
    }

    public class Patch : Module, IGroup<Chunk>
    {
        public HashSet<IResolvable<Chunk>> Members { get; }

        public Patch(Pack parent, string name, Guid id) : base(parent, name, id)
        {
            Members = new HashSet<IResolvable<Chunk>>();

            try
            {
                using (var data = GetDataStream())
                using (var reader = new BinaryReader(data))
                {
                    while (true)
                    {
                        long offset = reader.ReadInt64();
                        byte[] bytes = reader.ReadBytes(reader.ReadInt32());

                        var chunk = new Chunk(offset, bytes);

                        var conflictors = Members
                            .Select(c => c.ResolveSelf())
                            .Where(c => c.CanMergeWith(chunk));

                        if (conflictors.Any())
                        {
                            var conflict = new Conflict<Chunk>(chunk, new HashSet<Chunk>(conflictors));
                            throw new ConflictException<Chunk>("Diff parse failed! Diff cannot have conflicting hunks. Contact the developer of this pack to resolve the issue.", conflict);
                        }
                        else
                        {
                            Members.Add(chunk);
                        }
                    }
                }
            }
            catch (EndOfStreamException) { }
        }

        public Patch(Pack parent, string name, HashSet<IResolvable<Chunk>> chunks) : base(parent, name, Guid.Empty)
        {
            Members = chunks;
        }

        public override Stream GetDataStream()
        {
            return Parent.Archive.GetEntry($"{Name}.patch").Open();
        }

        public override IResolvable<Module> MergeWith(HashSet<Module> others)
        {
            if (others.All(m => m is Patch))
            {
                var otherGroups = new HashSet<IGroup<Chunk>>(
                    others.Cast<IGroup<Chunk>>());

                otherGroups.Add(this);

                return new ResolvingPatch(Parent, Name,
                    new MergeFilter<Chunk>()
                    {
                        Fallback = new GroupMerger<Chunk>(otherGroups)
                    });
            }
            else
            {
                return base.MergeWith(others);
            }
        }

        public override async Task LoadSelfAsync(CancellationToken token)
        {
            if (Root.Graph.Table[Name].Contains(Id)) return;

            var path = Path.Combine(Root.GamePath, Name);
            using (var stream = File.OpenWrite(path))
            {
                foreach (var chunk in Members.Select(m => m.ResolveSelf()))
                {
                    stream.Seek(chunk.Offset, SeekOrigin.Begin);
                    await stream.WriteAsync(chunk.Data, 0, chunk.Data.Length);
                }
            }

            Root.Graph.Table[Name].Add(Id);
        }
    }
}
