using FluentFTP;
using System.IO;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Abstract;
    using System.Linq;

    public class FTPFileSystem : IFileSystem
    {
        private string HostName { get; }

        private string UserName { get; }
        private string Password { get; }

        private string LocalDir { get; }
        private string TempDir { get; }

        private FtpClient Client { get; set; }

        public FTPFileSystem(string hostName, string userName, string password, string localDir, string tempDir)
        {
            HostName = hostName;

            UserName = userName;
            Password = password;

            LocalDir = localDir;
            TempDir = tempDir;
        }

        private async Task<bool> FileExistsAsync(string path)
        {
            var names = await Client.GetNameListingAsync();
            return FtpExtensions.FileExistsInNameListing(names.Select(n => n.ToLowerInvariant()).ToArray(), path.ToLowerInvariant());
        }

        public async Task MountAsync()
        {
            Directory.CreateDirectory(TempDir);

            Client = new FtpClient(HostName, UserName, Password);
            await Client.AutoConnectAsync();
        }

        public async Task<StagedFile> StageFileAsync(string path)
        {
            string tempFile = Path.Combine(TempDir, path);
            string localFilePath = LocalDir.CombineLocalPath(path).GetFtpPath();
            string localFileName = localFilePath.GetFtpFileName();

            string localDir = localFilePath.GetFtpDirectoryName();
            await Client.SetWorkingDirectoryAsync(localDir);

            if (await FileExistsAsync(localFileName))
            {
                await Client.DownloadFileAsync(tempFile, localFileName, FtpLocalExists.Overwrite);

                var stream = File.Open(tempFile, FileMode.Open, FileAccess.ReadWrite);
                var file = new StagedFile(path, stream);

                return file;
            }
            else
            {
                string tempDir = Path.GetDirectoryName(tempFile);

                Directory.CreateDirectory(tempDir);

                var stream = File.Open(tempFile, FileMode.Create, FileAccess.ReadWrite);
                var file = new StagedFile(path, stream);

                return file;
            }
        }

        public Task UnstageFileAsync(StagedFile file)
        {
            file.Stream.Dispose();
            return Task.Run(() => File.Delete(Path.Combine(TempDir, file.Path)));
        }

        public async Task CommitFileAsync(StagedFile file)
        {
            file.Stream.Dispose();

            string tempFile = Path.Combine(TempDir, file.Path);

            string localFilePath = LocalDir.CombineLocalPath(file.Path);

            string localFileDir = localFilePath.GetFtpDirectoryName();
            string localFileName = localFilePath.GetFtpFileName();

            await Client.SetWorkingDirectoryAsync(localFileDir);

            await Client.UploadFileAsync(tempFile, localFileName, FtpRemoteExists.Overwrite, true);
        }

        public async Task RemoveFileAsync(string path)
        {
            string localFilePath = LocalDir.CombineLocalPath(path).GetFtpFileName();

            string localFileDir = localFilePath.GetFtpDirectoryName();
            string localFileName = localFilePath.GetFtpFileName();

            await Client.SetWorkingDirectoryAsync(localFileDir);

            if (await FileExistsAsync(localFileName))
                await Client.DeleteFileAsync(localFileName);
        }

        public async Task UnmountAsync()
        {
            await Client.DisconnectAsync();
        }
    }
}
