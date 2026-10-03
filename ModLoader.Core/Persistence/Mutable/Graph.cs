using Newtonsoft.Json;

namespace ModLoader.Core.Persistence.Mutable
{
    public class Graph
    {
        public Dictionary<string, Guid> Table { get; }

        public Graph() 
        {
            Table = new();
        }

        internal Graph(Stored.Graph graph)
        {
            Table = new();

            foreach (var entry in graph.Table)
            {
                Table.Add(entry.Name, entry.Id);
            }
        }

        internal Stored.Graph Store()
        {
            var graph = new Stored.Graph();

            List<Stored.Graph.Entry> table = new();
            foreach ((string name, Guid id) in Table)
            {
                table.Add(new Stored.Graph.Entry
                {
                    Name = name,
                    Id = id
                });
            }

            graph.Table = table.ToArray();
            return graph;
        }

        public static async Task<Graph> LoadFromStreamAsync(Stream stream, bool useJson = false) 
        {
            if (useJson)
            {
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<Graph>(json);
                }
            }
            else
            {
                return new Graph(await Stored.Graph.LoadFromStreamAsync(stream));
            }
        }

        public async Task WriteToStreamAsync(Stream stream, bool compressed = false)
        {
            await Store().WriteToStreamAsync(stream, compressed);
        }
    }
}
