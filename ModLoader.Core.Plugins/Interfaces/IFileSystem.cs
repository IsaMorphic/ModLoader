namespace ModLoader.Core.Plugins.Interfaces
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

    public interface IFileSystem
    {
        Task MountAsync();

        Task<StagedFile> StageFileAsync(string path);
        Task UnstageFileAsync(StagedFile file);

        Task CommitFileAsync(StagedFile file);
        Task RemoveFileAsync(string path);

        Task UnmountAsync();
    }
}
