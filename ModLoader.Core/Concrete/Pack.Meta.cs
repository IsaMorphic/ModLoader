using CFS.SnabNet;
using Newtonsoft.Json;

namespace ModLoader.Core
{
    using Persistence.Types;

    public partial class Pack
    {
        [SnabStruct]
        public partial class Meta
        {
            [SnabField("Id", SnabGuid.TypeId)]
            public Guid Id { get; set; }

            [SnabField("Fallback", SnabGuid.TypeId)]
            public Guid? Fallback { get; set; }

            [SnabField]
            public string Name { get; set; }

            [SnabField]
            public string Author { get; set; }

            [SnabField]
            public string Notes { get; set; }

            public async Task WriteToStreamAsync(Stream stream, bool compressed = false)
            {
                SnabInstance instance = new();
                instance.RegisterType<SnabGuid>();

                using (var writer = instance.CreateWriter(stream, compressed ? 
                    SnabFlags.User | SnabFlags.Compressed : SnabFlags.User))
                {
                    writer.Serialize(this);
                }
            }

            public static async Task<Meta> LoadFromStreamAsync(Stream stream, bool useJson = false)
            {
                if (useJson)
                {
                    using (var reader = new StreamReader(stream))
                    using (var json = new JsonTextReader(reader))
                    {
                        var serializer = new JsonSerializer();
                        return serializer.Deserialize<Meta>(json);
                    }
                }
                else
                {
                    SnabInstance instance = new();
                    instance.RegisterType<SnabGuid>();

                    using (var reader = instance.CreateReader(stream))
                    {
                        return reader.Deserialize<Meta>();
                    }
                }
            }
        }
    }
}