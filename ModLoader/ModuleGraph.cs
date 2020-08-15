using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ModLoader
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

        public void WriteToStream(Stream stream)
        {
            using (var writer = new StreamWriter(stream))
                writer.Write(JsonConvert.SerializeObject(this));
        }

        public static ModuleGraph LoadFromStream(Stream stream)
        {
            using (var reader = new StreamReader(stream))
                return JsonConvert.DeserializeObject<ModuleGraph>(reader.ReadToEnd());
        }
    }
}
