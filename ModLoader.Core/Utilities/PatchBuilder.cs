using CFS.SnabNet;

namespace ModLoader.Core.Utilities
{
    public class PatchBuilder : IXunkBasedBuilder
    {
        private const int BLOCK_SIZE = 4 * 1024 * 1024;

        public string Name => "Patch";

        public string DefaultExt => ".patch";

        public async Task BuildAsync(string originalFilePath, string moddedFilePath, string outputFilePath)
        {
            List<Chunk.Data> chunks = new List<Chunk.Data>();

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
                            chunks.Add(new() { Offset = filePos + diffStart, Buffer = bytes });

                            diffStart = -1;
                            diffCount = 0;
                        }
                    }

                    filePos += bytesRead;

                    bytesRead = await originalFileStream.ReadAsync(bufferOrig, 0, BLOCK_SIZE);
                    await moddedFileStream.ReadExactlyAsync(bufferMod, 0, bytesRead);
                }
            }

            SnabInstance instance = new();

            using (var outputFileStream = File.Create(outputFilePath))
            using (var writer = instance.CreateWriter(outputFileStream, SnabFlags.None))
            {
                Patch.Data patch = new() { Chunks = chunks.ToArray() };
                writer.Serialize(patch);
            }
        }
    }
}
