using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ModLoader.Core.Utilities
{
    public class PatchBuilder
    {
        private const int BLOCK_SIZE = 4 * 1024 * 1024;

        private string PathToOriginal { get; }
        private string PathToModded { get; }

        public PatchBuilder(string pathToOriginal, string pathToModded)
        {
            PathToOriginal = pathToOriginal;
            PathToModded = pathToModded;
        }

        public async Task BuildAsync(string outputPath)
        {
            List<(long pos, byte[] data)> patches = new List<(long, byte[])>();

            using (var original = File.OpenRead(PathToOriginal))
            using (var modded = File.OpenRead(PathToModded))
            {
                if (modded.Length != original.Length)
                    throw new InvalidOperationException("Patch could not be created. The modified file is a different size than the original.");

                long filePos = 0;

                byte[] bufferOrig = new byte[BLOCK_SIZE];
                byte[] bufferMod = new byte[BLOCK_SIZE];

                int bytesRead = await original.ReadAsync(bufferOrig, 0, BLOCK_SIZE);
                await modded.ReadExactlyAsync(bufferMod, 0, bytesRead);

                while (bytesRead > 0)
                {
                    int diffStart = -1, diffCount = 0;
                    for (int i = 0; i < bytesRead; i++)
                    {
                        if (bufferOrig[i] != bufferMod[i])
                        {
                            if (diffStart < 0)
                            {
                                diffStart = i;
                            }

                            ++diffCount;
                        }
                        else if (diffStart >= 0)
                        {
                            byte[] bytes = new byte[diffCount];
                            
                            Array.Copy(bufferMod, diffStart, bytes, 0, diffCount);
                            patches.Add((filePos + diffStart, bytes));

                            diffStart = -1;
                            diffCount = 0;
                        }
                    }

                    filePos += bytesRead;

                    bytesRead = await original.ReadAsync(bufferOrig, 0, BLOCK_SIZE);
                    await modded.ReadExactlyAsync(bufferMod, 0, bytesRead);
                }
            }

            using (var output = File.Create(outputPath))
            using (var writer = new BinaryWriter(output))
            {
                foreach (var patch in patches)
                {
                    writer.Write(patch.pos);
                    writer.Write(patch.data.Length);
                    writer.Write(patch.data);
                }
            }
        }
    }
}
