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

            [SnabField]
            public HashId Id { get; set; }
        }

        [SnabField("Table", SnabType.Array)]
        public Entry[] Table { get; set; }

        internal async Task WriteToStreamAsync(Stream stream, bool compressed)
        {
            SnabInstance instance = new();
            instance.RegisterType<SnabHashId>();

            using (var writer = instance.CreateWriter(stream, compressed ? 
                SnabFlags.Compressed | SnabFlags.User : SnabFlags.User, 
                leaveOpen: true))
            {
                writer.Serialize(this);
            }
        }

        internal static async Task<Graph> LoadFromStreamAsync(Stream stream)
        {
            SnabInstance instance = new();
            instance.RegisterType<SnabHashId>();

            using (var memStream = new MemoryStream())
            {
                await stream.CopyToAsync(memStream);
                memStream.Position = 0;

                using (var reader = instance.CreateReader(memStream))
                {
                    return reader.Deserialize<Graph>();
                }
            }
        }
    }
}
