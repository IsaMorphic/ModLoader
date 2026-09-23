using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Abstract;
    using Persistence;

    public class BasePack : IPackBase
    {
        public Game Parent { get; }

        public string Name { get; }

        public Guid Id => MetaData.Id;

        public IResolvable<IPackBase> Fallback => null;

        public PackMeta MetaData { get; private set; }

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
        }

        public async Task ReadMetaDataAsync()
        {
            if (Initialized) return;

            var path = Path.Combine(Parent.ModPath, Name, "_meta.json");

            if (File.Exists(path))
            {
                using (var stream = File.OpenRead(path))
                {
                    MetaData = await PackMeta.LoadFromStreamAsync(stream);
                }
            }
            else
            {
                MetaData = new PackMeta
                {
                    Id = Guid.NewGuid(),
                    Fallback = null,
                    Name = null,
                    Author = null,
                    Notes = "This pack is missing its _meta.json file. Please update this pack to add some."
                };
            }
        }

        public async Task InitializeAsync(int dependencyLevel = 0)
        {
            if (Initialized) return;

            Directory.CreateDirectory(Path.Combine(Parent.ModPath, Name));

            if (MetaData == null)
            {
                await ReadMetaDataAsync();
            }

            if (File.Exists(Path.Combine(Parent.ModPath, Name, "_pack.json")))
            {
                try
                {
                    using (var stream = File.OpenRead(Path.Combine(Parent.ModPath, Name, "_pack.json")))
                    {
                        Graph = await Graph.LoadFromStreamAsync(stream);
                    }
                }
                catch
                {
                    using (var stream = File.OpenRead(Path.Combine(Parent.ModPath, Name, "_pack.json")))
                    {
                        Graph = new Graph(await GraphCompat.LoadFromStreamAsync(stream));
                    }
                }
            }
            else
            {
                Graph = new Graph();
                foreach (string filePath in Directory.EnumerateFiles(Parent.GamePath, "*.*", SearchOption.AllDirectories))
                {
                    Graph.Table.Add(Path.GetRelativePath(Parent.GamePath, filePath).ToLowerInvariant(), Guid.NewGuid());
                }

                using (var stream = File.OpenWrite(Path.Combine(Parent.ModPath, Name, "_pack.json")))
                {
                    await Graph.WriteToStreamAsync(stream);
                }
            }

            if (File.Exists(Path.Combine(Parent.ModPath, Name, "_pack.txt")))
            {
                using (var stream = File.OpenRead(Path.Combine(Parent.ModPath, Name, "_pack.txt")))
                using (var reader = new StreamReader(stream))
                {
                    MetaData.Notes = await reader.ReadToEndAsync();
                }
            }

            var packFiles = Directory.EnumerateFiles(
                Path.Combine(Parent.ModPath, Name), "*.*", SearchOption.AllDirectories)
                    .Select(entry => Path.GetRelativePath(Path.Combine(Parent.ModPath, Name), entry.ToLowerInvariant()))
                    .Where(entry =>
                    !entry.StartsWith("_pack") &&
                    !entry.StartsWith("_meta") &&
                    !entry.StartsWith("_fallback"));
            var gameFiles = Directory.EnumerateFiles(Parent.GamePath, "*.*", SearchOption.AllDirectories)
                .Select(entry => Path.GetRelativePath(Parent.GamePath, entry.ToLowerInvariant()));
            HashSet<string> entries = [.. packFiles, .. gameFiles];
            foreach (var entry in entries)
            {
                string name = entry.ToLowerInvariant();
                Guid id = Graph.Table[name];

                var module = new Module(this, name, id);
                Members.Add(name, module);
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

        public override string ToString()
        {
            return MetaData.Name ?? Name;
        }

        public Stream GetStream(string name)
        {
            string packFilePath = Path.Combine(Parent.ModPath, Name, name);
            string gameFilePath = Path.Combine(Parent.GamePath, name);

            if (File.Exists(packFilePath))
            {
                return File.OpenRead(packFilePath);
            }
            else if (File.Exists(gameFilePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(packFilePath));
                File.Copy(gameFilePath, packFilePath, true);
                return File.OpenRead(packFilePath);
            }
            else
            {
                throw new FileNotFoundException($"The file '{name}' was not found in the base pack or the game directory.");
            }
        }

        public void Unload()
        {
            Members.Clear();
        }
    }
}
