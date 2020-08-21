using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    public class Patch : Module
    {
        public Dictionary<long, byte[]> Patches { get; }

        public Patch(string name, Guid id, Pack parent) : base(name, id, parent)
        {
            Patches = new Dictionary<long, byte[]>();
        }

        public override Task InitializeAsync()
        {
            return Task.Run(() =>
            {
                try
                {
                    using (Data = Parent.Archive.GetEntry($"{Name}.patch").Open())
                    using (var reader = new BinaryReader(Data))
                    {
                        while (true)
                        {
                            long offset = reader.ReadInt64();
                            byte[] bytes = reader.ReadBytes(reader.ReadInt32());
                            Patches.Add(offset, bytes);
                        }
                    }
                }
                catch (EndOfStreamException) { }
            });
        }

        public override bool ConflictsWith(Module other)
        {
            bool conflicted = base.ConflictsWith(other);
            if (conflicted && other is Patch)
            {
                var patch = other as Patch;

                var combined = Patches
                    .Concat(patch.Patches)
                    .OrderBy(p => p.Key)
                    .ToArray();

                for (int i = 0; i < combined.Length - 1; i++)
                {
                    long patchStart = combined[i].Key;
                    int patchLength = combined[i].Value.Length;

                    long nextStart = combined[i + 1].Key;

                    if (patchStart + patchLength > nextStart) 
                        return true;
                }

                return false;
            }
            else 
                return base.ConflictsWith(other);
        }

        protected override async Task LoadSelfAsync()
        {
            if (Root.Graph.Table[Name].Contains(Id)) return;

            var path = Path.Combine(Root.GamePath, Name);
            using (var stream = File.OpenWrite(path))
            {
                foreach (var patch in Patches)
                {
                    stream.Seek(patch.Key, SeekOrigin.Begin);
                    await stream.WriteAsync(patch.Value, 0, patch.Value.Length);
                }
            }

            Root.Graph.Table[Name].Add(Id);
        }
    }
}
