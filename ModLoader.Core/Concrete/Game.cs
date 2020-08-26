using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Abstract;
    using Exceptions;
    using Filters;
    using Persistence;
    using System.Security.Cryptography.X509Certificates;
    using Utilities;

    public class Game
    {
        public string BasePath { get; }

        public string ModPath { get; }
        public string GamePath { get; }

        public string GraphPath { get; }
        public string ConfigPath { get; }
        public string ScriptPath { get; }

        public IEnumerable<Pack> Packs { get; }

        public Pack BasePack { get; private set; }

        public Graph Graph { get; private set; }

        public Config Config { get; private set; }

        public GroupMerger<Module> Merger { get; }

        public IResolvable<IGroup<Module>> Modules { get; set; }

        public Game(string basePath)
        {
            BasePath = basePath;

            ModPath = Path.Combine(BasePath, "Mods");
            GamePath = Path.Combine(BasePath, "Game");

            GraphPath = Path.Combine(GamePath, "_pack.json");
            ConfigPath = Path.Combine(GamePath, "_config.json");
            ScriptPath = Path.Combine(GamePath, "_script.bat");

            Merger = new GroupMerger<Module>();

            Packs = Merger.Mergers.Cast<Pack>();

            Modules = new MergeFilter<Module>
            {
                Fallback = new FallbackFilter<Module>
                {
                    Fallback = Merger
                }
            };
        }

        public async Task InitializeAsync()
        {
            BasePack = new Pack(this, "_base_");

            try
            {
                await BasePack.InitializeAsync();
            }
            catch (Exception)
            {
                await PackBuilder
                    .FromDirectory(GamePath)
                    .WithBitmap(new Image<Rgba32>(100, 100))
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

                Config = new Config();
                await SaveConfigAsync();

                File.WriteAllText(ScriptPath, "echo Nothing to do!");
            }

            await LoadGraphAsync();

            foreach (var file in Directory.EnumerateFiles(ModPath, "*.zip"))
            {
                var packName = Path.GetFileNameWithoutExtension(file);
                if (packName == "_base_") continue;

                var pack = new Pack(this, packName);
                await pack.InitializeAsync();

                Merger.Mergers.Add(pack);
            }

            await LoadConfigAsync();
        }

        public async Task LoadConfigAsync()
        {
            using (var stream = File.OpenRead(ConfigPath))
                Config = await Config.LoadFromStreamAsync(stream);

            foreach (var packConfig in Config.Packs)
            {
                var pack = Packs.Single(p => p.Name == packConfig.Key);

                var fallback = Packs.SingleOrDefault(p => p.Name == packConfig.Value.Fallback);

                pack.Enabled = packConfig.Value.Enabled;
                pack.Fallback = fallback;

                foreach (var moduleConfig in packConfig.Value.Modules)
                {
                    var module = pack.Members
                        .Select(m => m.ResolveSelf())
                        .Single(m => m.Name == moduleConfig.Key);

                    if (moduleConfig.Value.Enabled != packConfig.Value.Enabled)
                        module.Enabled = moduleConfig.Value.Enabled;

                    void LoadXunks<T>()
                        where T : Xunk<T>
                    {
                        if (moduleConfig.Value.Xunks == null) return;

                        var group = module as XunkGroup<T>;
                        foreach (var xunkConfig in moduleConfig.Value.Xunks)
                        {
                            var xunk = group.Members.Select(x => x.ResolveSelf())
                                .Single(x => x.Offset == xunkConfig.Key);

                            if (xunkConfig.Value.Enabled != moduleConfig.Value.Enabled)
                                xunk.Enabled = xunkConfig.Value.Enabled;
                        }
                    }

                    if (module is Diff)
                        LoadXunks<Hunk>();
                    else if (module is Patch)
                        LoadXunks<Chunk>();
                }
            }
        }

        public async Task SaveConfigAsync()
        {
            foreach (var pack in Packs)
            {
                var packConfig = new Config.Pack()
                {
                    Enabled = pack.Enabled,
                    Fallback = pack.Fallback?.ResolveSelf().Name,
                };

                foreach (var module in pack.Members.Cast<Module>())
                {
                    if (!packConfig.Modules.ContainsKey(module.Name))
                        packConfig.Modules.Add(module.Name, null);

                    Dictionary<long, Config.Xunk> xunks = null;

                    void SaveXunks<T>()
                        where T : Xunk<T>
                    {
                        var group = module as XunkGroup<T>;

                        xunks = new Dictionary<long, Config.Xunk>();
                        foreach (var member in group.Members.Select(m => m.ResolveSelf()))
                        {
                            xunks.Add(member.Offset, new Config.Xunk
                            {
                                Enabled = member.Enabled
                            });
                        }
                    }

                    if (module is Diff)
                        SaveXunks<Hunk>();
                    else if (module is Patch)
                        SaveXunks<Chunk>();

                    packConfig.Modules[module.Name] = new Config.Module(xunks)
                    {
                        Enabled = module.Enabled
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
                Graph = await Graph.LoadFromStreamAsync(stream);
        }

        public async Task SaveGraphAsync()
        {
            using (var stream = File.Create(GraphPath))
                await Graph.WriteToStreamAsync(stream);
        }

        public async Task ExecuteLoadScript()
        {
            var proc = Process.Start(ScriptPath);
            await Task.Run(proc.WaitForExit);

            if (proc.ExitCode != 0) throw new ScriptExecutionException($"_script.bat halted with exit code: {proc.ExitCode}", proc.ExitCode);
        }

        public async Task LoadModulesAsync(CancellationToken token)
        {
            foreach (var module in Modules.Resolve().Members.Select(m => m.Resolve()))
            {
                await module.LoadAsync(token);
            }
        }

        public async Task ReloadBaseModulesAsync(CancellationToken token)
        {
            var modules = Packs
                .SelectMany(m => m.Members)
                .Select(m => m.ResolveSelf())
                .Where(m => m.Resolve() == null)
                .Concat(Modules.Resolve().Members
                    .Select(m => m.Resolve())
                    .Where(m => m.Id == Guid.Empty))
                .Select(m => BasePack.Members
                    .Select(b => b.Resolve())
                    .Where(b => b != null)
                    .Single(b => b.Name == m.Name))
                .Distinct();

            foreach (var module in modules)
            {
                await module.LoadAsync(token);
            }
        }
    }
}
