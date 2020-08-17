using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ModLoader.Core.Persistence
{
    public class ModuleGraph
    {
        public Dictionary<string, Guid> Table { get; }

        public ModuleGraph()
        {
            Table = new Dictionary<string, Guid>();
        }

        public ModuleGraph(Dictionary<string, Guid> table)
        {
            Table = table;
        }

        public async Task WriteToStreamAsync(Stream stream)
        {
            using (var writer = new StreamWriter(stream))
                await writer.WriteAsync(JsonConvert.SerializeObject(this));
        }

        public static async Task<ModuleGraph> LoadFromStreamAsync(Stream stream)
        {
            using (var reader = new StreamReader(stream))
                return JsonConvert.DeserializeObject<ModuleGraph>(await reader.ReadToEndAsync());
        }
    }
}
