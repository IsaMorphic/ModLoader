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
    using Utilities;

    public class Game
    {
        public string BasePath { get; }

        public string ModPath { get; }
        public string GamePath { get; private set; }

        public string GraphPath { get; }
        public string ConfigPath { get; }
        public string ScriptPath { get; }

        public string Name { get; }

        public GameManager Parent { get; }

        public Graph Graph { get; private set; }
        public Config Config { get; private set; }

        public IEnumerable<Pack> Packs { get; }
        public Pack BasePack { get; private set; }

        public GroupMerger<Module> Merger { get; }
        public IResolvable<IGroup<Module>> Modules { get; set; }

        public Game(GameManager parent, string name)
        {
            Parent = parent;

            Name = name;

            BasePath = Path.Combine(Parent.BasePath, Name);

            ModPath = Path.Combine(BasePath, "Mods");

            GraphPath = Path.Combine(BasePath, "_pack.json");
            ConfigPath = Path.Combine(BasePath, "_config.json");
            ScriptPath = Path.Combine(BasePath, "_script.bat");

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

        public async Task InitializeAsync(string gamePath)
        {
            Directory.CreateDirectory(BasePath);

            GamePath = gamePath;

            Config = new Config(GamePath);
            await SaveConfigAsync();

            await new PackBuilder(GamePath, ModPath, "_base_")
                    .WithBitmap(new Image<Rgba32>(100, 100))
                    .WithNote("Base Game (DO NOT DELETE!)")
                    .BuildAsync();

            BasePack = new Pack(this, "_base_");
            await BasePack.InitializeAsync();

            using (var stream = File.Create(GraphPath))
                await BasePack.Graph.WriteToStreamAsync(stream);

            File.WriteAllText(ScriptPath, "echo Nothing to do!");
        }

        public async Task LoadAsync()
        {
            BasePack = new Pack(this, "_base_");
            await BasePack.InitializeAsync();

            await LoadGraphAsync();

            foreach (var file in Directory.EnumerateFiles(ModPath, "*.zip"))
            {
                var packName = Path.GetFileNameWithoutExtension(file).ToLowerInvariant();
                if (packName == "_base_") continue;

                var pack = new Pack(this, packName);
                await pack.InitializeAsync();

                Merger.Mergers.Add(pack);
            }

            await LoadConfigAsync();
        }

        public async Task UnloadAsync()
        {
            await BasePack.UnloadAsync();

            foreach (var pack in Packs)
            {
                await pack.UnloadAsync();
            }
            Merger.Mergers.Clear();
        }

        public async Task LoadConfigAsync()
        {
            using (var stream = File.OpenRead(ConfigPath))
                Config = await Config.LoadFromStreamAsync(stream);

            GamePath = Config.GamePath;

            foreach (var packConfig in Config.Packs)
            {
                var pack = Packs.SingleOrDefault(p => p.Name == packConfig.Key);

                if (pack == null) continue;

                var fallback = Packs.SingleOrDefault(p => p.Name == packConfig.Value.Fallback);

                pack.Enabled = packConfig.Value.Enabled;
                pack.Fallback = fallback;

                foreach (var moduleConfig in packConfig.Value.Modules)
                {
                    var module = pack.Members
                        .Select(m => m.ResolveSelf())
                        .SingleOrDefault(m => m.Name == moduleConfig.Key);

                    if (module == null) continue;

                    module.Enabled = moduleConfig.Value.Enabled;

                    void LoadXunks<T>()
                        where T : Xunk<T>
                    {
                        if (moduleConfig.Value.Xunks == null) return;

                        var group = module as XunkGroup<T>;
                        foreach (var xunkConfig in moduleConfig.Value.Xunks)
                        {
                            var xunk = group.Members.Select(x => x.ResolveSelf())
                                .SingleOrDefault(x => x.Offset == xunkConfig.Key);

                            if (xunk == null) continue;

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
            var startInfo = new ProcessStartInfo(ScriptPath);

            startInfo.WorkingDirectory = BasePath;
            startInfo.Environment["GAME_PATH"] = GamePath;
            startInfo.UseShellExecute = false;

            var proc = Process.Start(startInfo);
            await Task.Run(proc.WaitForExit);

            if (proc.ExitCode != 0) throw new ScriptExecutionException($"_script.bat halted with exit code: {proc.ExitCode}", proc.ExitCode);
        }

        public Task RunGameAsync()
        {
            var exePath = Directory.EnumerateFiles(GamePath, "*.exe").Single();

            var proc = Process.Start(exePath);
            return Task.Run(proc.WaitForExit);
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
                    .Where(m => m.Id == Guid.Empty));

            var toLoad = modules
                .Select(m => BasePack.Members
                    .Select(b => b.Resolve())
                    .Where(b => b != null)
                    .SingleOrDefault(b => b.Name == m.Name))
                .Where(m => m != null)
                .Distinct();

            var toRemove = modules
                .Where(m => !BasePack.Members
                    .Select(b => b.Resolve())
                    .Where(b => b != null)
                    .Any(b => b.Name == m.Name))
                .Distinct();

            foreach (var module in toLoad)
            {
                await module.LoadAsync(token);
            }

            foreach (var module in toRemove)
            {
                var path = Path.Combine(GamePath, module.Name);
                await Task.Run(() => File.Delete(path));
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
