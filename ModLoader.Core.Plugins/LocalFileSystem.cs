namespace ModLoader.Core.Plugins
{
    using Interfaces;

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

            return Task.Run(() =>
            {
                File.Copy(tempFile, localFile, true);
                File.Delete(tempFile);
            });
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

    public class LocalFileSystemPlugin : IPlugin<IFileSystem>
    {
        public string Name => typeof(LocalFileSystem).FullName;

        public string Author => "IsaMorphic((a34308ed70bc1b881c453f2a15f6a8e5140e963b))";

        public string Description => "-----BEGIN PGP SIGNED MESSAGE-----\r\nHash: SHA256\r\n\r\n.NET System.IO wrapper for ModLoader's filesystem interface\r\n-----BEGIN PGP SIGNATURE-----\r\n\r\niQGzBAEBCAAdFiEEo0MI7XC8G4gcRT8qFfao5RQOljsFAmN1N0IACgkQFfao5RQO\r\nljvAXAv+LpScxuaw5jOV5NLipQoxL/nROJ4eBuLdTyInL11qnlgexFcII8essEny\r\noDzfrHcDdizC9QTjErHCxfhkJ2CGU11nfBzh5CS75XsWGWHfnHVZhBnVGHweCWgB\r\nRDc0ezGZQq3JxLqKFyWbRuYevipyZTF9YYsN2ESgh5rejWq53s5gLgUsNb11XtCp\r\nhbNJh223I4kNAK6b96BKsvD1S1QsdQVWcjaP5f54eHqkznjLgHekq3Jd1oQuSaBx\r\nKYzXLtbljoR+CpwThlt4T8fMBc8CJxdRu2INv0K8OJ1AFz4MoTDlTQ5Ek6XM/FG4\r\nnK9We8Es5BRWKou6/CJKipImJ3P75BFSYlR5WllO06WgMvRDvfeoVHU/cjiAyR8N\r\nOz4e8qH0GtgsRxCvjJbr6HMCNlL6G/zAYk/aEkWCqhtPgqUjTawBg3TLM+YVhSvg\r\na8C60YHrtWT8fPNDWUIJc22vvDQjuuTjxmxXTuXFOxDbeMps4F/PrXyLxWuJqpSS\r\ngk1iuYPX\r\n=OywE\r\n-----END PGP SIGNATURE-----\r\n";

        public string[] ConfigItems => new[] { "LocalDir", "TempDir" }; 

        public IFileSystem CreateInstance(IReadOnlyDictionary<string, string> configOptions)
        {
            return new LocalFileSystem(configOptions["LocalDir"], configOptions["TempDir"]);
        }
    }
}