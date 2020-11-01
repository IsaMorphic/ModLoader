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
            public bool Enabled { get; set; }
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
            public bool Enabled { get; set; }
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
            public bool Enabled { get; set; }
        }

        public string GamePath { get; }

        public Dictionary<string, string> Extras { get; }

        public Dictionary<string, Pack> Packs { get; }

        internal Config(string gamePath)
        {
            GamePath = gamePath;
            Packs = new Dictionary<string, Pack>();
            Extras = new Dictionary<string, string>();
        }

        public Config(string gamePath, Dictionary<string, Pack> packs, Dictionary<string, string> extras)
        {
            GamePath = gamePath;
            Packs = packs;
            Extras = extras;
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
