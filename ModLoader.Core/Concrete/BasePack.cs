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

        public Guid Id { get; }

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

        public async Task InitializeAsync(int dependencyLevel = 0)
        {
            if (Initialized) return;

            Directory.CreateDirectory(Path.Combine(Parent.ModPath, Name));

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

        public Task CopyModuleAsync(string name) 
        {
            return Task.Run(() =>
            {
                string gameFilePath = Path.Combine(Parent.GamePath, name);
                string packFilePath = Path.Combine(Parent.ModPath, Name, name);
                if (!File.Exists(packFilePath) && File.Exists(gameFilePath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(packFilePath));
                    File.Copy(gameFilePath, packFilePath, true);
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
