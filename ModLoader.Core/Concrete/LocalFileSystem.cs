using System.IO;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Abstract;

    public class LocalFileSystem : IFileSystem
    {
        public string LocalDir { get; }
        public string TempDir { get; }

        public LocalFileSystem(string localDir, string tempDir)
        {
            LocalDir = localDir;
            TempDir = tempDir;
        }

        public Task MountAsync()
        {
            Directory.CreateDirectory(TempDir);
            return Task.CompletedTask;
        }

        public Task<StagedFile> StageFileAsync(string path)
        {
            string tempFile = Path.Combine(TempDir, path);
            string tempDir = Path.GetDirectoryName(tempFile);

            Directory.CreateDirectory(tempDir);

            var stream = File.Open(tempFile, FileMode.Create, FileAccess.ReadWrite);
            var file = new StagedFile(path, stream);

            return Task.FromResult(file);
        }

        public Task UnstageFileAsync(StagedFile file)
        {
            file.Stream.Dispose();
            return Task.Run(() => File.Delete(Path.Combine(TempDir, file.Path)));
        }

        public Task CommitFileAsync(StagedFile file)
        {
            file.Stream.Flush();
            file.Stream.Dispose();

            string tempFile = Path.Combine(TempDir, file.Path);
            string localFile = Path.Combine(LocalDir, file.Path);

            string localDir = Path.GetDirectoryName(localFile);
            Directory.CreateDirectory(localDir);

            return Task.Run(() => File.Copy(tempFile, localFile, true))
                .ContinueWith(t => File.Delete(tempFile));
        }

        public Task RemoveFileAsync(string path)
        {
            string localFile = Path.Combine(LocalDir, path);
            return Task.Run(() => File.Delete(localFile));
        }

        public Task UnmountAsync()
        {
            return Task.CompletedTask;
        }
    }
}
