
using System.Security.Cryptography;

namespace ModLoader.Core
{
    using Abstract;
    using Exceptions;
    using Persistence.Mutable;
    using Utilities.Hashing;

    public class BasePack : IPackBase
    {
        public Game Parent { get; }

        public string Name { get; }

        public Guid Id { get; }

        public bool IsArchive => true;

        public IResolvable<IPackBase> Fallback => null;

        public IDictionary<string, Module> Members { get; }
        IEnumerable<Module> IGroup<Module>.Members => Members.Values;

        public Graph Graph { get; private set; }

        public bool Initialized { get; private set; }

        public bool Enabled { get; set; }

        public BasePack(Game parent)
        {
            Parent = parent;

            Name = "_base_";

            Members = new Dictionary<string, Module>();

            Enabled = true;

            Id = Guid.NewGuid();
        }

        public async Task InitializeAsync()
        {
            if (Initialized) return;

            Directory.CreateDirectory(Path.Combine(Parent.ModPath, Name));

            if (File.Exists(Path.Combine(Parent.ModPath, Name, "_pack.snab")))
            {
                using (var stream = File.OpenRead(Path.Combine(Parent.ModPath, Name, "_pack.snab")))
                {
                    Graph = await Graph.LoadFromStreamAsync(stream);
                }
            }
            else if (File.Exists(Path.Combine(Parent.ModPath, Name, "_pack.json")))
            {
                using (var stream = File.OpenRead(Path.Combine(Parent.ModPath, Name, "_pack.json")))
                {
                    Graph = await Graph.LoadFromStreamAsync(stream, useJson: true);
                }

                using (var stream = File.OpenWrite(Path.Combine(Parent.ModPath, Name, "_pack.snab")))
                {
                    await Graph.WriteToStreamAsync(stream, compressed: true);
                }

                File.Delete(Path.Combine(Parent.ModPath, Name, "_pack.json"));
            }
            else
            {
                Graph = new Graph();
                foreach (string filePath in Directory.EnumerateFiles(Parent.Config.GamePath, "*.*", SearchOption.AllDirectories))
                {
                    string name = Path.GetRelativePath(Parent.Config.GamePath, filePath);
                    using (var stream = File.OpenRead(filePath))
                    {
                        HashId id;
                        if (Parent.Config.UseFullBackup)
                        {
                            string copyFilePath = Path.Combine(Parent.ModPath, Name, name);
                            string dirPath = Path.GetDirectoryName(copyFilePath);
                            Directory.CreateDirectory(dirPath);

                            using (var copyStream = File.Create(copyFilePath))
                            using (var sha256Stream = new SHA256Stream(copyStream))
                            {
                                await stream.CopyToAsync(sha256Stream);
                                id = sha256Stream.GetHash();
                            }
                        }
                        else 
                        {
                            id = new(await SHA256.HashDataAsync(stream));
                        }

                        Graph.Table.Add(name.ToLowerInvariant(), id);
                    }
                }

                using (var stream = File.OpenWrite(Path.Combine(Parent.ModPath, Name, "_pack.snab")))
                {
                    await Graph.WriteToStreamAsync(stream, compressed: true);
                }
            }

            var packFiles = Directory.EnumerateFiles(
                Path.Combine(Parent.ModPath, Name), "*.*", SearchOption.AllDirectories)
                    .Select(entry => Path.GetRelativePath(Path.Combine(Parent.ModPath, Name), entry.ToLowerInvariant()))
                    .Where(entry =>
                    !entry.StartsWith("_pack") &&
                    !entry.StartsWith("_meta") &&
                    !entry.StartsWith("_fallback"));
            var gameFiles = Directory.EnumerateFiles(Parent.Config.GamePath, "*.*", SearchOption.AllDirectories)
                .Select(entry => Path.GetRelativePath(Parent.Config.GamePath, entry.ToLowerInvariant()));
            HashSet<string> entries = [.. packFiles, .. gameFiles];
            foreach (var entry in entries)
            {
                string name = entry.ToLowerInvariant();
                if (Graph.Table.TryGetValue(name, out HashId id))
                {
                    var module = new Module(this, name, id);
                    Members.Add(name, module);
                }
            }

            Initialized = true;
        }

        public IPackBase ResolveSelf() => this;

        public async Task LoadSelfAsync()
        {
            foreach (var module in Members.Values)
            {
                await module.Resolve()?.LoadAsync();
            }
        }

        public async Task<bool> CopyModuleAsync(string name)
        {
            string packFilePath = Path.Combine(Parent.ModPath, Name, name);
            if (!Parent.Config.UseFullBackup && 
                Graph.Table.TryGetValue(name, out HashId cachedId) &&
                !File.Exists(packFilePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(packFilePath));
                try
                {
                    HashId actualId;
                    using (var stream = File.Create(packFilePath))
                    using (var sha256Stream = new SHA256Stream(stream))
                    {
                        await Parent.Files.PullFileAsync(name, sha256Stream);
                        actualId = sha256Stream.GetHash();
                    }

                    if (actualId == cachedId)
                    {
                        return true;
                    }
                    else
                    {
                        File.Delete(packFilePath);
                        throw new HashMismatchException($"Hash mismatch for base module '{name}'. Restore the original file before loading your mods!");
                    }
                }
                catch (ArgumentException) { }
            }

            return false;
        }

        public Task<bool> RemoveModuleAsync(string name)
        {
            return Task.Run(() =>
            {
                string packFilePath = Path.Combine(Parent.ModPath, Name, name);
                if (!Parent.Config.UseFullBackup && File.Exists(packFilePath))
                {
                    File.Delete(packFilePath);
                    return true;
                }
                else
                {
                    return false;
                }
            });
        }

        public Stream GetStream(string name)
        {
            string packFilePath = Path.Combine(Parent.ModPath, Name, name);
            return File.OpenRead(packFilePath);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
