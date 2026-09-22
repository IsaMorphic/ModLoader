using FluentFTP;

namespace ModLoader.Core.Plugins
{
    using Interfaces;

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

            await Client.UploadFileAsync(tempFile, check.realName ?? localFileName, FtpRemoteExists.Overwrite, true);

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

    public class FTPFileSystemPlugin : IPlugin<IFileSystem>
    {
        public string Name => typeof(FTPFileSystem).FullName;

        public string Author => "IsaMorphic((a34308ed70bc1b881c453f2a15f6a8e5140e963b))";

        public string Description => "-----BEGIN PGP SIGNED MESSAGE-----\r\nHash: SHA256\r\n\r\nFTP Server implementation using FluentFTP for ModLoader's filesystem interface\r\n-----BEGIN PGP SIGNATURE-----\r\n\r\niQGzBAEBCAAdFiEEo0MI7XC8G4gcRT8qFfao5RQOljsFAmN1O/UACgkQFfao5RQO\r\nljv8ZAv/XOrEhBJo5/F804y7KmSLL0980u5acCdPrsgqNOQVeQ0SPuzQ9EqdA80m\r\nLZDVyV610dSNRARGX0s1XWNDEpuBDPg955ZCi07pbU3l54DXLciYCoVkfaORTwLE\r\ncSkuxcMdpahSwmrpU/38pcJMQLrniHRili42rLZAq+gjNRDRSHx0eIrIMgvjMtBZ\r\nmGeSZab5hOb+hFfw7XzNIg/MvIowmRicSKavyTn3gAjxhoiuXfXVz/1n7gmY4ttV\r\nKQwB4EgKmbp4X11cUbwO2zfDGgeTkmWczmqxhRQ6z+MAVTImMWUwc2IVTh6KFj5D\r\nCY+z1ezHz6C7sSJJrj4WdkbiYnd8HeMkS6dDE8FdGbNpRKWS52uXAHe/bikVEixU\r\nGOJUSiQFUDsQONjPn1xBcjvMwKpqG1UVo6+VxkjaBcAHvWffTBFabo2WmSUEuyf9\r\n5xhCH8l8aoXqaOzm55BSUIvEsJT+jLptYq1t3K+JRWWOl+2bb6OoWeFrLzMUhooR\r\naCH6QuY9\r\n=N3O3\r\n-----END PGP SIGNATURE-----\r\n";

        public string[] ConfigItems => new[] { "HostName", "UserName", "Password", "LocalDir", "TempDir" };

        public IFileSystem CreateInstance(IReadOnlyDictionary<string, string> configOptions)
        {
            return new FTPFileSystem(
                configOptions["HostName"],
                configOptions["UserName"],
                configOptions["Password"],
                configOptions["LocalDir"],
                configOptions["TempDir"]
                );
        }
    }
}
