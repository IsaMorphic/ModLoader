using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ModLoader
{
    public class GameConfig
    {
        public class PackConfig
        {
            public bool Enabled { get; set; }
            public string Fallback { get; set; }

            public Dictionary<string, ModuleConfig> Modules { get; }

            public PackConfig()
            {
                Modules = new Dictionary<string, ModuleConfig>();
            }

            public PackConfig(Dictionary<string, ModuleConfig> modules)
            {
                Modules = modules;
            }
        }

        public class ModuleConfig
        {
            public bool Enabled { get; set; }
        }

        public string LaunchPath { get; set; }

        public Dictionary<string, PackConfig> Packs { get; }

        public GameConfig()
        {
            Packs = new Dictionary<string, PackConfig>();
        }

        public GameConfig(Dictionary<string, PackConfig> packs) 
        {
            Packs = packs;
        }

        public async Task WriteToStreamAsync(Stream stream)
        {
            using (var writer = new StreamWriter(stream))
                await writer.WriteAsync(JsonConvert.SerializeObject(this));
        }

        public static async Task<GameConfig> LoadFromStreamAsync(Stream stream)
        {
            using (var reader = new StreamReader(stream))
                return JsonConvert.DeserializeObject<GameConfig>(await reader.ReadToEndAsync());
        }
    }
}
