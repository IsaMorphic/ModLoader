using CFS.SnabNet;
using Newtonsoft.Json;

namespace ModLoader.Core
{
    public partial class Pack
    {
        [SnabStruct]
        public partial class Meta
        {
            [SnabField]
            public Guid Id { get; set; }

            [SnabField]
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

                using (var writer = instance.CreateWriter(stream, compressed ? 
                    SnabFlags.Compressed : SnabFlags.None, 
                    leaveOpen: true))
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

                    using (var memStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memStream);
                        memStream.Position = 0;

                        using (var reader = instance.CreateReader(memStream))
                        {
                            return reader.Deserialize<Meta>();
                        }
                    }
                }
            }
        }
    }
}