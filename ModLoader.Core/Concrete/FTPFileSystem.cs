using FluentFTP;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Abstract;

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

        private async Task<(bool exists, string realName)> CheckFileAsync(string path)
        {
            var names = await Client.GetNameListingAsync();
            var lower = names
                .Select(n => n.ToLowerInvariant())
                .ToArray();

            var p = path.ToLowerInvariant();

            var i = Array.IndexOf(lower, p);

            if (i < 0)
                return (false, null);
            else
                return (true, names[i]);
        }

        public async Task MountAsync()
        {
            Directory.CreateDirectory(TempDir);

            Client = new FtpClient(HostName, UserName, Password);
            await Client.AutoConnectAsync();
        }

        public async Task<StagedFile> StageFileAsync(string path, bool createNew = false)
        {
            string tempFile = Path.Combine(TempDir, path);
            string localFilePath = LocalDir.CombineLocalPath(path).GetFtpPath();
            string localFileName = localFilePath.GetFtpFileName();

            string localDir = localFilePath.GetFtpDirectoryName();
            await Client.SetWorkingDirectoryAsync(localDir);

            var check = await CheckFileAsync(localFileName);

            if (check.exists && !createNew)
            {
                await Client.DownloadFileAsync(tempFile, check.realName, FtpLocalExists.Overwrite);

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
            file.Stream.Flush();
            file.Stream.Dispose();

            string tempFile = Path.Combine(TempDir, file.Path);

            string localFilePath = LocalDir.CombineLocalPath(file.Path).GetFtpPath();

            string localFileDir = localFilePath.GetFtpDirectoryName();
            string localFileName = localFilePath.GetFtpFileName();

            var check = await CheckFileAsync(localFileName);

            await Client.SetWorkingDirectoryAsync(localFileDir);

            await Client.UploadFileAsync(tempFile, check.realName, FtpRemoteExists.Overwrite, true);

            await Task.Run(() => File.Delete(Path.Combine(TempDir, file.Path)));
        }

        public async Task RemoveFileAsync(string path)
        {
            string localFilePath = LocalDir.CombineLocalPath(path).GetFtpPath();

            string localFileDir = localFilePath.GetFtpDirectoryName();
            string localFileName = localFilePath.GetFtpFileName();

            await Client.SetWorkingDirectoryAsync(localFileDir);

            var check = await CheckFileAsync(localFileName);

            if (check.exists)
                await Client.DeleteFileAsync(check.realName);
        }

        public async Task UnmountAsync()
        {
            await Client.DisconnectAsync();
        }
    }
}
