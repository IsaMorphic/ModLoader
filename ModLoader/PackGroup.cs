using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ModLoader
{
    public class PackGroup : GroupMerger<Pack, Module>
    {
        public string BasePath { get; }

        public string ModPath { get; }
        public string GamePath { get; }

        public string GraphPath { get; }

        public Pack BasePack { get; }

        public ModuleGraph Graph { get; }

        public PackGroup(string basePath) : base("_none_", new HashSet<Pack>())
        {
            BasePath = basePath;

            ModPath = Path.Combine(BasePath, "Mods");
            GamePath = Path.Combine(BasePath, "Game");

            GraphPath = Path.Combine(GamePath, "_pack.json");

            try
            {
                BasePack = new Pack("_base_", this);
            }
            catch (Exception)
            {
                PackBuilder
                    .FromDirectory(GamePath)
                    .WithBitmap(new System.Drawing.Bitmap(100, 100))
                    .WithNote("Base Game (DO NOT DELETE!)")
                    .WithName("_base_")
                    .Build();

                File.Move(
                    Path.Combine(BasePath, "_base_.zip"), 
                    Path.Combine(ModPath, "_base_.zip")
                    );

                BasePack = new Pack("_base_", this);

                using (var stream = File.Create(GraphPath))
                    BasePack.Graph.WriteToStream(stream);
            }

            using (var stream = File.OpenRead(GraphPath))
                Graph = ModuleGraph.LoadFromStream(stream);

            var files = Directory.GetFiles(ModPath);
            foreach (var file in files.Where(path => path.EndsWith(".zip")))
            {
                var packName = Path.GetFileNameWithoutExtension(file);
                if (packName == "_base_") continue;

                var pack = new Pack(packName, this);
                Mergers.Add(pack);
            }
        }

        public void SaveConfig()
        {
            Graph.WriteToStream(File.Create(GraphPath));
        }
    }
}
