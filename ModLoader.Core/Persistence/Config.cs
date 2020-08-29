using ModLoader.Core.Abstract;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ModLoader.Core.Persistence
{
    public class Config
    {
        public class Pack
        {
            public bool? Enabled { get; set; }
            public string Fallback { get; set; }

            public Dictionary<string, Module> Modules { get; }

            public Pack()
            {
                Modules = new Dictionary<string, Module>();
            }

            public Pack(Dictionary<string, Module> modules)
            {
                Modules = modules;
            }
        }

        public class Module
        {
            public bool? Enabled { get; set; }
            public Dictionary<long, Xunk> Xunks { get; }

            public Module()
            {
                Xunks = new Dictionary<long, Xunk>();
            }

            public Module(Dictionary<long, Xunk> xunks)
            {
                Xunks = xunks;
            }
        }

        public class Xunk
        {
            public bool? Enabled { get; set; }
        }

        public string LaunchPath { get; set; }

        public Dictionary<string, Pack> Packs { get; }

        public Config()
        {
            Packs = new Dictionary<string, Pack>();
        }

        public Config(Dictionary<string, Pack> packs)
        {
            Packs = packs;
        }

        public async Task WriteToStreamAsync(Stream stream)
        {
            using (var writer = new StreamWriter(stream))
                await writer.WriteAsync(JsonConvert.SerializeObject(this));
        }

        public static async Task<Config> LoadFromStreamAsync(Stream stream)
        {
            using (var reader = new StreamReader(stream))
                return JsonConvert.DeserializeObject<Config>(await reader.ReadToEndAsync());
        }
    }
}
