namespace ModLoader.Core.Persistence.Mutable
{
    public class Config
    {
        public class Pack
        {
            public string Name { get; set; }
            public bool Enabled { get; set; }
            public string Fallback { get; set; }

            public Dictionary<string, Module> Modules { get; }

            public Pack()
            {
                Modules = new();
            }

            internal Pack(Stored.Config.Pack pack)
            {
                Modules = new();

                Enabled = pack.Enabled;

                Fallback = pack.Fallback;

                foreach(var module in pack.Modules)
                {
                    Modules.Add(module.Name, new Module(module));
                }
            }

            internal Stored.Config.Pack Store()
            {
                var pack = new Stored.Config.Pack
                {
                    Enabled = Enabled,
                    Fallback = Fallback,
                };

                List<Stored.Config.Module> modules = new();
                foreach ((string name, Module module) in Modules)
                {
                    modules.Add(module.Store());
                }

                pack.Modules = modules.ToArray();
                return pack;
            }
        }

        public class Module
        {
            public bool Enabled { get; set; }
            public Dictionary<long, Xunk> Xunks { get; }

            public Module()
            {
                Xunks = new();
            }

            internal Module(Stored.Config.Module module)
            {
                Xunks = new();

                Enabled = module.Enabled;

                foreach(var xunk in module.Xunks)
                {
                    Xunks.Add(xunk.Offset, new Xunk(xunk));
                }
            }

            internal Stored.Config.Module Store()
            {
                var module = new Stored.Config.Module
                {
                    Enabled = Enabled,
                };

                List<Stored.Config.Xunk> xunks = new();
                foreach ((long offset, Xunk xunk) in Xunks)
                {
                    xunks.Add(xunk.Store());
                }

                module.Xunks = xunks.ToArray();
                return module;
            }
        }

        public class Xunk
        {
            public bool Enabled { get; set; }

            public Xunk() { }

            internal Xunk(Stored.Config.Xunk xunk)
            {
                Enabled = xunk.Enabled;
            }

            internal Stored.Config.Xunk Store()
            {
                return new Stored.Config.Xunk
                {
                    Enabled = Enabled
                };
            }
        }

        public class Handler
        {
            public string Name { get; set; }

            public string Type { get; set; }

            public Handler() { }

            internal Handler(Stored.Config.Handler handler)
            {
                Name = handler.Name;
                Type = handler.Type;
            }

            internal Stored.Config.Handler Store()
            {
                return new Stored.Config.Handler
                {
                    Name = Name,
                    Type = Type
                };
            }
        }

        public class Plugin 
        {
            public string Name { get; set; }

            public Dictionary<string, string> Items { get; }

            public Plugin()
            {
                Items = new();
            }

            internal Plugin(Stored.Config.Plugin plugin)
            {
                Name = plugin.Name;

                Items = new();
                foreach (var item in plugin.Items)
                {
                    Items.Add(item.Name, item.Value);
                }
            }

            internal Stored.Config.Plugin Store()
            {
                var plugin = new Stored.Config.Plugin
                {
                    Name = Name,
                };

                List<Stored.Config.Plugin.Item> items = new();
                foreach ((string name, string value) in Items)
                {
                    items.Add(new Stored.Config.Plugin.Item { Name = name, Value = value });
                }

                plugin.Items = items.ToArray();
                return plugin;
            }
        }

        public string GamePath { get; set; }

        public Dictionary<string, Pack> Packs { get; }

        public Dictionary<string, Handler> Handlers { get; }

        public Dictionary<string, Plugin> Plugins { get; }

        internal Config(Stored.Config config) 
        {
            Packs = new();
            Handlers = new();
            Plugins = new();

            foreach(var pack in config.Packs)
            {
                Packs.Add(pack.Name, new Pack(pack));
            }

            foreach(var handler in config.Handlers)
            {
                Handlers.Add(handler.Name, new Handler(handler));
            }

            foreach(var plugin in config.Plugins)
            {
                Plugins.Add(plugin.Name, new Plugin(plugin));
            } 
        }

        public Config() 
        {
            Packs = new();
            Handlers = new();
            Plugins = new();
        }

        internal Stored.Config Store()
        {
            var config = new Stored.Config() 
            { 
                GamePath = GamePath,
            };

            List<Stored.Config.Pack> packs = new();
            foreach ((string name, Pack pack) in Packs)
            {
                packs.Add(pack.Store());
            }

            List<Stored.Config.Handler> handlers = new();
            foreach ((string name, Handler handler) in Handlers)
            {
                handlers.Add(handler.Store());
            }

            List<Stored.Config.Plugin> plugins = new();
            foreach ((string name, Plugin plugin) in Plugins)
            {
                plugins.Add(plugin.Store());
            }

            return config;
        }

        public bool TryAddHandler(Handler handler) 
        {
            return Handlers.TryAdd(handler.Name, handler);
        }

        public bool TryAddPlugin(Plugin plugin)
        {
            return Plugins.TryAdd(plugin.Name, plugin);
        }

        public bool TryAddPack(Pack pack)
        {
            return Packs.TryAdd(pack.Name, pack);
        }

        public Task WriteToStreamAsync(Stream stream) 
        {
            return Store().WriteToStreamAsync(stream);
        }

        public static async Task<Config> LoadFromStreamAsync(Stream stream) 
        {
            var config = await Stored.Config.LoadFromStreamAsync(stream);
            return new Config(config);
        }
    }
}
