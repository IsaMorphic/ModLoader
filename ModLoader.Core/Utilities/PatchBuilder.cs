using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ModLoader.Core.Utilities
{
    public class PatchBuilder : IXunkBasedBuilder<PatchBuilder>
    {
        private const int BLOCK_SIZE = 4 * 1024 * 1024;

        public string Name => "Patch";

        public string DefaultExt => ".patch";

        public async Task BuildAsync(string originalFilePath, string moddedFilePath, string outputFilePath)
        {
            List<(long pos, byte[] data)> patches = new List<(long, byte[])>();

            using (var originalFileStream = File.OpenRead(originalFilePath))
            using (var moddedFileStream = File.OpenRead(moddedFilePath))
            {
                if (moddedFileStream.Length != originalFileStream.Length)
                    throw new InvalidOperationException("Patch could not be created. The modified file is a different size than the original.");

                long filePos = 0;

                byte[] bufferOrig = new byte[BLOCK_SIZE];
                byte[] bufferMod = new byte[BLOCK_SIZE];

                int bytesRead = await originalFileStream.ReadAsync(bufferOrig, 0, BLOCK_SIZE);
                await moddedFileStream.ReadExactlyAsync(bufferMod, 0, bytesRead);

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

                    bytesRead = await originalFileStream.ReadAsync(bufferOrig, 0, BLOCK_SIZE);
                    await moddedFileStream.ReadExactlyAsync(bufferMod, 0, bytesRead);
                }
            }

            using (var outputFileStream = File.Create(outputFilePath))
            using (var writer = new BinaryWriter(outputFileStream))
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
