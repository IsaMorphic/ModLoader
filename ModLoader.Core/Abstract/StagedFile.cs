using System.IO;

namespace ModLoader.Core.Abstract
{
    public class StagedFile
    {
        public string Path { get; }
        public Stream Stream { get; }

        public StagedFile(string path, Stream stream)
        {
            Path = path;
            Stream = stream;
        }
    }
}
