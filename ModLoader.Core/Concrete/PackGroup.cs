using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Persistence;
    using Utilities;

    public class PackGroup : GroupMerger<Pack, Module>
    {
        public string BasePath { get; }

        public string ModPath { get; }
        public string GamePath { get; }

        public string GraphPath { get; }
        public string ConfigPath { get; }

        public Pack BasePack { get; private set; }

        public ModuleGraph Graph { get; private set; }

        public GameConfig Config { get; private set; }

        public PackGroup(string basePath) : base("_none_", new HashSet<Pack>())
        {
            BasePath = basePath;

            ModPath = Path.Combine(BasePath, "Mods");
            GamePath = Path.Combine(BasePath, "Game");

            GraphPath = Path.Combine(GamePath, "_pack.json");
            ConfigPath = Path.Combine(GamePath, "_config.json");
        }

        public async Task InitializeAsync()
        {
            BasePack = new Pack("_base_", this);

            try
            {
                await BasePack.InitializeAsync();
            }
            catch (Exception)
            {
                await PackBuilder
                    .FromDirectory(GamePath)
                    .WithBitmap(new SKBitmap(100, 100))
                    .WithNote("Base Game (DO NOT DELETE!)")
                    .WithName("_base_")
                    .BuildAsync()
                    .ContinueWith(t =>
                    {
                        File.Move(
                            Path.Combine(BasePath, "_base_.zip"),
                            Path.Combine(ModPath, "_base_.zip")
                            );
                    });

                await BasePack.InitializeAsync();

                using (var stream = File.Create(GraphPath))
                    await BasePack.Graph.WriteToStreamAsync(stream);

                Config = new GameConfig();
                await SaveConfigAsync();
            }

            await LoadGraphAsync();

            foreach (var file in Directory.EnumerateFiles(ModPath, "*.zip"))
            {
                var packName = Path.GetFileNameWithoutExtension(file);
                if (packName == "_base_") continue;

                var pack = new Pack(packName, this);
                await pack.InitializeAsync();

                Mergers.Add(pack);
            }

            await LoadConfigAsync();
        }

        public async Task LoadConfigAsync()
        {
            using (var stream = File.OpenRead(ConfigPath))
                Config = await GameConfig.LoadFromStreamAsync(stream);

            foreach (var packConfig in Config.Packs)
            {
                var pack = Mergers.Single(p => p.Name == packConfig.Key);
                var fallback = Mergers.SingleOrDefault(p => p.Name == packConfig.Value.Fallback);

                pack.Enabled = packConfig.Value.Enabled;
                pack.Fallback = fallback;

                foreach (var moduleConfig in packConfig.Value.Modules)
                {
                    var module = pack.Members.Single(m => m.Name == moduleConfig.Key);
                    if (moduleConfig.Value.Enabled != packConfig.Value.Enabled)
                        module.Enabled = moduleConfig.Value.Enabled;
                }
            }
        }

        public async Task SaveConfigAsync()
        {
            foreach (var pack in Mergers)
            {
                var packConfig = new GameConfig.PackConfig()
                {
                    Enabled = pack.Enabled,
                    Fallback = pack.Fallback?.Name,
                };

                foreach (var module in pack.Members.Cast<Module>())
                {
                    if (!packConfig.Modules.ContainsKey(module.Name))
                        packConfig.Modules.Add(module.Name, null);
                    packConfig.Modules[module.Name] = new GameConfig.ModuleConfig()
                    {
                        Enabled = module.Enabled,
                    };
                }

                if (!Config.Packs.ContainsKey(pack.Name))
                    Config.Packs.Add(pack.Name, null);
                Config.Packs[pack.Name] = packConfig;
            }

            using (var stream = File.Create(ConfigPath))
                await Config.WriteToStreamAsync(stream);
        }

        public async Task LoadGraphAsync()
        {
            using (var stream = File.OpenRead(GraphPath))
                Graph = await ModuleGraph.LoadFromStreamAsync(stream);
        }

        public async Task SaveGraphAsync()
        {
            using (var stream = File.Create(GraphPath))
                await Graph.WriteToStreamAsync(stream);
        }

        public Task ReloadBaseModulesAsync()
        {
            return Task.WhenAll(Mergers
                .SelectMany(m => m.Members)
                .Cast<Module>()
                .Where(m => m.Resolve() == null)
                .Where(m => Graph.Table.Values.Contains(m.Id))
                .Select(m => BasePack.Members.Single(b => b.Name == m.Name))
                .Distinct()
                .Select(m => m.LoadAsync()));
        }
    }
}
