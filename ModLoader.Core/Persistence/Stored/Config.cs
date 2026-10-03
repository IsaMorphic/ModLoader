using CFS.SnabNet;

namespace ModLoader.Core.Persistence.Stored
{
    using Persistence.Types;

    [SnabStruct]
    public partial class Config
    {
        [SnabStruct]
        public partial class Handler
        {
            [SnabField]
            public string Name { get; set; }

            [SnabField]
            public string Type { get; set; }
        }

        [SnabStruct]
        public partial class Plugin 
        {
            [SnabStruct]
            public partial class Item
            {
                [SnabField]
                public string Name { get; set; }

                [SnabField]
                public string Value { get; set; }
            }

            [SnabField]
            public string Name { get; set; }

            [SnabField("Items", SnabType.Array)]
            public Item[] Items { get; set; }
        }

        [SnabStruct]
        public partial class Pack
        {
            [SnabField]
            public bool Enabled { get; set; }

            [SnabField]
            public string Name { get; set; }

            [SnabField]
            public string Fallback { get; set; }

            [SnabField("Modules", SnabType.Array)]
            public Module[] Modules { get; set; }
        }

        [SnabStruct]
        public partial class Module
        {
            [SnabField]
            public bool Enabled { get; set; }

            [SnabField]
            public string Name { get; set; }

            [SnabField("Xunks", SnabType.Array)]
            public Xunk[] Xunks { get; set; }
        }

        [SnabStruct]
        public partial class Xunk
        {
            [SnabField]
            public bool Enabled { get; set; }

            [SnabField]
            public long Offset { get; set; }
        }

        [SnabField]
        public string GamePath { get; set; }

        [SnabField("Packs", SnabType.Array)]
        public Pack[] Packs { get; set; }

        [SnabField("Handlers", SnabType.Array)]
        public Handler[] Handlers { get; set; }

        [SnabField("Plugins", SnabType.Array)]
        public Plugin[] Plugins { get; set; }

        internal async Task WriteToStreamAsync(Stream stream, bool compressed)
        {
            SnabInstance instance = new();
            instance.RegisterType<SnabGuid>();

            using (var writer = instance.CreateWriter(stream, compressed ? 
                SnabFlags.User | SnabFlags.Compressed : SnabFlags.User, 
                leaveOpen: true))
            {
                writer.Serialize(this);
            }   
        }

        internal static async Task<Config> LoadFromStreamAsync(Stream stream)
        {
            SnabInstance instance = new();
            instance.RegisterType<SnabGuid>();

            using (var memStream = new MemoryStream())
            {
                await stream.CopyToAsync(memStream);
                memStream.Position = 0;

                using (var reader = instance.CreateReader(memStream))
                {
                    return reader.Deserialize<Config>();
                }
            }
        }
    }
}
