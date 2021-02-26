using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Abstract;
    using Exceptions;
    using Filters;
    using Persistence;
    using System;
    using Utilities;

    public class Game
    {
        public static Stream DefaultPackImageStream { get; set; }
        public static string DefaultPackNote { get; set; }

        public string BasePath { get; }

        public string ModPath { get; }
        public string TempPath { get; }
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

        public GroupMerger<Prioritized<Module, string>> Merger { get; }
        public IPotential<IGroup<IPotential<Module>>> Modules { get; set; }

        public IFileSystem Files { get; private set; }

        public Game(GameManager parent, string name)
        {
            Parent = parent;

            Name = name;

            BasePath = Path.Combine(Parent.BasePath, Name);

            ModPath = Path.Combine(BasePath, "Mods");
            TempPath = Path.Combine(BasePath, "_tmp");

            GraphPath = Path.Combine(BasePath, "_pack.json");
            ConfigPath = Path.Combine(BasePath, "_config.json");
            ScriptPath = Path.Combine(BasePath, "_script.bat");

            Merger = new GroupMerger<Prioritized<Module, string>>();

            Packs = Merger.Mergers.Cast<Pack>();

            var priority = new WhereFilter<Module>(
                new ResolveFilter<Module>(
                new PriorityFilter<Module>(
                    new MergeFilter<IResolvable<Module>, string>(
                        Merger
                        )
                    )), m => m.Parent != BasePack);
            Modules =
                new MergeFilter<Module, string>(
                    new GroupMerger<Module>(
                        new HashSet<IPotential<IGroup<Module>>>
                        {
                            new WhereFilter<Module>(
                                priority,
                                m => m.GetType() == typeof(Module) || m.GetType() == typeof(Burn)
                                ),
                            new PotentialFilter<Module>(
                                new GroupMerger<IPotential<Module>>(
                                    new HashSet<IPotential<IGroup<IPotential<Module>>>>
                                    {
                                        new XunkFallbackFilter<Hunk>(
                                            new PrioritizeFilter<Module, string>(
                                                new WhereFilter<Module>(
                                                    priority,
                                                    m => m.GetType() == typeof(Diff)
                                                    )
                                                )
                                            ),
                                        new XunkFallbackFilter<Chunk>(
                                            new PrioritizeFilter<Module, string>(
                                                new WhereFilter<Module>(
                                                    priority,
                                                    m => m.GetType() == typeof(Patch)
                                                    )
                                                )
                                            )
                                    })
                                )
                    }));
        }

        public async Task InitializeAsync(string gamePath)
        {
            Directory.CreateDirectory(BasePath);

            GamePath = gamePath;

            Config = new Config(GamePath);
            await SaveConfigAsync();

            var baseMeta = new Pack.Meta
            {
                Id = Guid.NewGuid(),
                Fallback = null,
                Name = "Base Game",
                Author = "ModLoader",
                Notes = "Base Game (DO NOT DELETE!)"
            };

            await new PackBuilder(GamePath, ModPath, "_base_")
                    .WithImageStream(Stream.Null)
                    .WithMetaData(baseMeta)
                    .BuildAsync();

            BasePack = new Pack(this, "_base_");
            await BasePack.InitializeAsync();

            using (var stream = File.Create(GraphPath))
                await BasePack.Graph.WriteToStreamAsync(stream);

            File.WriteAllText(ScriptPath, "echo Nothing to do!");
        }

        public async Task UnloadAsync()
        {
            if (Files != null)
                await Files.UnmountAsync();

            if (BasePack != null)
            {
                BasePack.Enabled = false;
                BasePack = null;
            }

            foreach (var pack in Packs)
            {
                pack.Unload();
            }

            Merger.Mergers.Clear();
        }

        public async Task RebuildTestPacksAsync()
        {
            var dirs = Directory.GetDirectories(ModPath);

            foreach (var dir in dirs)
            {
                string name = Path.GetFileName(dir);

                var meta = new Pack.Meta
                {
                    Id = Guid.NewGuid(),
                    Fallback = null,
                    Name = $"[TEST] {name}",
                    Author = "You",
                    Notes = DefaultPackNote
                };

                await new PackBuilder(dir, name)
                    .WithImageStream(DefaultPackImageStream)
                    .WithMetaData(meta)
                    .BuildAsync();
            }
        }

        public async Task ReloadAsync()
        {
            await UnloadAsync();

            await RebuildTestPacksAsync();

            BasePack = new Pack(this, "_base_");
            await BasePack.InitializeAsync();

            await LoadGraphAsync();

            foreach (var file in Directory.EnumerateFiles(ModPath, "*.zip"))
            {
                var packName = Path.GetFileNameWithoutExtension(file).ToLowerInvariant();
                if (packName == "_base_") continue;

                var pack = new Pack(this, packName);
                Merger.Mergers.Add(pack);
            }

            foreach (var pack in Packs)
            {
                await pack.ReadMetaDataAsync();
            }

            foreach (var pack in Packs)
            {
                await pack.InitializeAsync();
            }

            await LoadConfigAsync();

            if (Config.Extras != null && Config.Extras.ContainsKey("FileHandler"))
            {
                switch (Config.Extras["FileHandler"])
                {
                    case "FTP":
                        Files = new FTPFileSystem(Config.Extras["HostName"], Config.Extras["UserName"], Config.Extras["Password"], GamePath, TempPath);
                        break;
                }
            }
            else
            {
                Files = new LocalFileSystem(GamePath, TempPath);
            }

            await Files.MountAsync();
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

                pack.Enabled = packConfig.Value.Enabled;

                foreach (var moduleConfig in packConfig.Value.Modules)
                {
                    if (!pack.Members.ContainsKey(moduleConfig.Key)) continue;

                    var module = pack.Members[moduleConfig.Key];
                    module.Enabled = moduleConfig.Value.Enabled;

                    void LoadXunks<T>()
                        where T : Xunk<T>
                    {
                        if (moduleConfig.Value.Xunks == null) return;

                        var group = module as XunkGroup<T>;
                        foreach (var xunkConfig in moduleConfig.Value.Xunks)
                        {
                            var xunk = group.Xunks.Select(x => x.ResolveSelf())
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
                    Fallback = null
                };

                foreach (var module in pack.Members.Values.Cast<Module>())
                {
                    if (!packConfig.Modules.ContainsKey(module.Name))
                        packConfig.Modules.Add(module.Name, null);

                    Dictionary<long, Config.Xunk> xunks = null;

                    void SaveXunks<T>()
                        where T : Xunk<T>
                    {
                        var group = module as XunkGroup<T>;

                        xunks = new Dictionary<long, Config.Xunk>();
                        foreach (var member in group.Xunks.Select(m => m.ResolveSelf()))
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
            try
            {
                using (var stream = File.OpenRead(GraphPath))
                {
                    Graph = await Graph.LoadFromStreamAsync(stream);
                }
            }
            catch
            {
                using (var stream = File.OpenRead(GraphPath))
                {
                    Graph = new Graph(await GraphCompat.LoadFromStreamAsync(stream));
                }
            }

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

            var startInfo = new ProcessStartInfo(exePath)
            { WorkingDirectory = GamePath };

            var proc = Process.Start(startInfo);
            return Task.Run(proc.WaitForExit);
        }

        public HashSet<Module> ResolveModules()
        {
            var modules = Modules
                .ResolveSelf().Members
                .Select(m => m.ResolveSelf())
                .ToHashSet();

            var ex = modules
                .Where(m => m is IExceptional)
                .SelectMany(m => (m as IExceptional).Errors)
                .FirstOrDefault();

            if (ex != null) throw ex;

            return modules;
        }

        public async Task LoadModulesAsync(HashSet<Module> modules)
        {
            foreach (var module in modules)
            {
                await module.LoadAsync();
            }
        }

        public async Task ReloadBaseModulesAsync()
        {
            var @base = BasePack.Members.Values
                .Select(m => m.ResolveSelf());

            var active = Modules.ResolveSelf().Members
                .Select(m => m.ResolveSelf());

            var inactive = Packs
                .SelectMany(m => m.Members.Values)
                .Select(m => m.ResolveSelf())
                .Where(m => !active.Any(n => n.Name == m.Name));

            var toLoad = inactive
                .Select(m => @base.SingleOrDefault(n => n.Name == m.Name))
                .Where(m => m != null)
                .Distinct();

            var toRemove = inactive
                .Where(m => !@base.Any(b => b.Name == m.Name) && Graph.Table.ContainsKey(m.Name))
                .Distinct();

            foreach (var module in toLoad)
            {
                await module.LoadAsync();
            }

            foreach (var module in toRemove)
            {
                Graph.Table.Remove(module.Name);
                await Files.RemoveFileAsync(module.Name);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
