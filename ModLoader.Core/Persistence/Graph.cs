using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ModLoader.Core.Persistence
{
    public class Graph
    {
        public Dictionary<string, HashSet<Guid>> Table { get; }

        public Graph()
        {
            Table = new Dictionary<string, HashSet<Guid>>();
        }

        public Graph(Dictionary<string, HashSet<Guid>> table)
        {
            Table = table;
        }

        public async Task WriteToStreamAsync(Stream stream)
        {
            using (var writer = new StreamWriter(stream))
                await writer.WriteAsync(JsonConvert.SerializeObject(this));
        }

        public static async Task<Graph> LoadFromStreamAsync(Stream stream)
        {
            using (var reader = new StreamReader(stream))
                return JsonConvert.DeserializeObject<Graph>(await reader.ReadToEndAsync());
        }
    }
}
