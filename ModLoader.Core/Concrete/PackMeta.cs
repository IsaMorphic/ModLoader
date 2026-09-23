using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    public class PackMeta
    {
        public Guid Id { get; set; }
        public Guid? Fallback { get; set; }

        public string Name { get; set; }
        public string Author { get; set; }
        public string Notes { get; set; }

        public async Task WriteToStreamAsync(Stream stream)
        {
            using (var writer = new StreamWriter(stream))
                await writer.WriteAsync(JsonConvert.SerializeObject(this));
        }

        public static async Task<PackMeta> LoadFromStreamAsync(Stream stream)
        {
            using (var reader = new StreamReader(stream))
                return JsonConvert.DeserializeObject<PackMeta>(await reader.ReadToEndAsync());
        }
    }
}
