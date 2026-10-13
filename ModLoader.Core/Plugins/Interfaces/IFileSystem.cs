namespace ModLoader.Core.Plugins.Interfaces
{
    using Utilities.Hashing;

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

    public interface IFileSystem
    {
        Task MountAsync();

        Task PullFileAsync(string path, Stream stream);

        public async Task<HashId> HashFileAsync(string path)
        {
            using (var sha256Stream = new SHA256Stream(Stream.Null))
            {
                await PullFileAsync(path, sha256Stream);
                return sha256Stream.GetHash();
            }
        }

        Task<StagedFile> StageFileAsync(string path);
        Task UnstageFileAsync(StagedFile file);

        Task CommitFileAsync(StagedFile file);
        Task LinkFileAsync(string sourceFilePath, string destFilePath);
        Task RemoveFileAsync(string path);

        Task UnmountAsync();
    }
}
