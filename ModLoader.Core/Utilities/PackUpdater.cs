using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader.Core.Utilities
{
    using Persistence;
    using System.IO;

    public class PackUpdater : IDisposable
    {
        private bool disposedValue;

        public enum UpdateType
        {
            None,
            Remove,
            Add,
            Replace,
        }

        public class Update
        {
            public UpdateType Type { get; set; }
            public string FilePath { get; set; }
        }

        public class Module
        {
            public string Name { get; }
            public Update Update { get; }

            public Module(string name)
            {
                Name = name;
                Update = new Update();
            }

            public override string ToString()
            {
                return $"[ACTION: {Update.Type}] {Name}";
            }
        }

        public Pack Pack { get; }     
        
        public string PackPath { get; }

        public ZipArchive Archive { get; private set; }
        public Dictionary<string, Module> Modules { get; private set; }

        public Graph Graph { get; private set; }
        public Pack.Meta MetaData { get; private set; }

        public string ImagePath { get; set; }

        public PackUpdater(Pack pack)
        {
            Pack = pack;
            Pack.Unload();
            PackPath = Path.Combine(Pack.Parent.ModPath, $"{Pack.Name}.zip");
        }

        public async Task RevertChangesAsync()
        {
            Archive?.Dispose();
            Archive = ZipFile.Open(PackPath, ZipArchiveMode.Update);

            if (Archive.GetEntry("_meta.json") != null)
            {
                using (var stream = Archive.GetEntry("_meta.json").Open())
                {
                    MetaData = await Pack.Meta.LoadFromStreamAsync(stream);
                }
            }
            else
            {
                MetaData = new Pack.Meta
                {
                    Id = Guid.NewGuid(),
                    Fallback = null,
                    Name = null,
                    Author = null,
                    Notes = "This pack is missing its _meta.json file. Please update this pack to add some."
                };
            }

            try
            {
                using (var stream = Archive.GetEntry("_pack.json").Open())
                {
                    Graph = await Graph.LoadFromStreamAsync(stream);
                }
            }
            catch
            {
                using (var stream = Archive.GetEntry("_pack.json").Open())
                {
                    Graph = new Graph(await GraphCompat.LoadFromStreamAsync(stream));
                }
            }

            var noteEntry = Archive.GetEntry("_pack.txt");
            if (noteEntry != null)
            {
                using (var stream = noteEntry.Open())
                using (var reader = new StreamReader(stream))
                {
                    MetaData.Notes = await reader.ReadToEndAsync();
                }
            }

            var fallbackEntry = Archive.GetEntry("_fallback.txt");
            if (fallbackEntry != null)
            {
                string fallback;

                using (var stream = fallbackEntry.Open())
                using (var reader = new StreamReader(stream))
                    fallback = (await reader.ReadLineAsync()).ToLowerInvariant();
                
                MetaData.Fallback = Pack.Parent.Packs.SingleOrDefault(p => p.Name == fallback)?.Id;
            }

            Modules = new Dictionary<string, Module>();

            var entries = Archive.Entries.Where(entry => !entry.FullName.ToLowerInvariant().StartsWith("_pack") && !entry.FullName.ToLowerInvariant().StartsWith("_meta") && !entry.FullName.ToLowerInvariant().StartsWith("_fallback") && !entry.FullName.ToLowerInvariant().EndsWith("/"));
            foreach (var entry in entries)
            {
                Modules.Add(entry.FullName, new Module(entry.FullName));
            }
        }

        public async Task SaveChangesAsync()
        {
            foreach (var module in Modules.Values)
            {
                var update = module.Update;
                switch (update.Type)
                {
                    case UpdateType.Remove:
                        Archive.GetEntry(module.Name).Delete();
                        Graph.Table.Remove(module.Name);
                        break;

                    case UpdateType.Add:
                        Archive.CreateEntryFromFile(update.FilePath, module.Name);
                        Graph.Table.Add(module.Name, Guid.NewGuid());
                        break;

                    case UpdateType.Replace:
                        Archive.GetEntry(module.Name).Delete();
                        Archive.CreateEntryFromFile(update.FilePath, module.Name);
                        Graph.Table[module.Name] = Guid.NewGuid();
                        break;
                }
            }

            Archive.GetEntry("_fallback.txt")?.Delete();
            Archive.GetEntry("_pack.txt")?.Delete();

            if (ImagePath != null)
            {
                Archive.GetEntry("_pack.png").Delete();
                Archive.CreateEntryFromFile(ImagePath, "_pack.png");
            }

            Archive.GetEntry("_pack.json").Delete();
            using (var stream = Archive.CreateEntry("_pack.json").Open())
                await Graph.WriteToStreamAsync(stream);

            Archive.GetEntry("_meta.json")?.Delete();
            using (var stream = Archive.CreateEntry("_meta.json").Open())
                await MetaData.WriteToStreamAsync(stream);

            Archive.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Archive?.Dispose();
                    Pack.Reload();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
