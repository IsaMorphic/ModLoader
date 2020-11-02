using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ModLoader.Core.Persistence
{
    public class GraphCompat
    {
        public Dictionary<string, HashSet<Guid>> Table { get; }

        public GraphCompat()
        {
            Table = new Dictionary<string, HashSet<Guid>>();
        }

        public GraphCompat(Dictionary<string, HashSet<Guid>> table)
        {
            Table = table;
        }

        public async Task WriteToStreamAsync(Stream stream)
        {
            using (var writer = new StreamWriter(stream))
                await writer.WriteAsync(JsonConvert.SerializeObject(this));
        }

        public static async Task<GraphCompat> LoadFromStreamAsync(Stream stream)
        {
            using (var reader = new StreamReader(stream))
                return JsonConvert.DeserializeObject<GraphCompat>(await reader.ReadToEndAsync());
        }
    }
}
