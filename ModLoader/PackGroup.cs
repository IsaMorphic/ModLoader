using System.Collections.Generic;
using System.IO;

namespace ModLoader
{
    public class PackGroup : GroupMerger<Pack, Module>
    {
        public string BasePath { get; }

        public string ModPath { get; }
        public string GamePath { get; }

        public PackGroup(string basePath) : base("_none_", new HashSet<Pack>())
        {
            BasePath = basePath;

            ModPath = Path.Combine(BasePath, "Mods");
            GamePath = Path.Combine(BasePath, "Game");

            var files = Directory.GetFiles(ModPath);
            foreach (var file in files)
            {
                var packName = Path.GetFileNameWithoutExtension(file);
                var pack = new Pack(packName, this);
                Mergers.Add(pack);
            }
        }
    }
}
