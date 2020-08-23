using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    public class Patch : Module
    {
        public Dictionary<long, byte[]> Patches { get; }

        public Patch(Pack parent, string name, Guid id) : base(parent, name, id)
        {
            Patches = new Dictionary<long, byte[]>();
            try
            {
                using (var data = GetDataStream())
                using (var reader = new BinaryReader(data))
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
        }

        public override Stream GetDataStream()
        {
            return Parent.Archive.GetEntry($"{Name}.patch").Open();
        }

        public override bool CanMergeWith(Module other)
        {
            bool conflicted = base.CanMergeWith(other);
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
                return base.CanMergeWith(other);
        }

        public override async Task LoadSelfAsync(CancellationToken token)
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
