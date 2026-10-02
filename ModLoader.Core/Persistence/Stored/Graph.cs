using CFS.SnabNet;

namespace ModLoader.Core.Persistence.Stored
{
    using Persistence.Types;

    [SnabStruct]
    public partial class Graph
    {
        [SnabStruct]
        public partial class Entry
        {
            [SnabField]
            public string Name { get; set; }

            [SnabField("Id", SnabGuid.TypeId)]
            public Guid Id { get; set; }
        }

        [SnabField("Entries", SnabType.Array)]
        public Entry[] Entries { get; set; }

        public async Task WriteToStreamAsync(Stream stream)
        {
            SnabInstance instance = new();
            instance.RegisterType<SnabGuid>();

            using (var writer = instance.CreateWriter(stream, SnabFlags.User | SnabFlags.Compressed))
            {
                writer.Serialize(this);
            }
        }

        public static async Task<Graph> LoadFromStreamAsync(Stream stream)
        {
            SnabInstance instance = new();
            instance.RegisterType<SnabGuid>();

            using (var reader = instance.CreateReader(stream))
            {
                return reader.Deserialize<Graph>();
            }
        }
    }
}
