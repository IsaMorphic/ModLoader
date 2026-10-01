using System;
using System.Collections.Generic;

namespace ModLoader.Core.Persistence.Mutable
{
    public class Graph
    {
        public Dictionary<string, Guid> Entries { get; }

        public Graph(Stored.Graph graph)
        {
            Entries = new();

            foreach (var entry in graph.Entries)
            {
                Entries.Add(entry.Name, entry.Id);
            }
        }

        public Stored.Graph Store()
        {
            var graph = new Stored.Graph();

            List<Stored.Graph.Entry> entries = new();
            foreach ((string name, Guid id) in Entries)
            {
                entries.Add(new Stored.Graph.Entry
                {
                    Name = name,
                    Id = id
                });
            }

            graph.Entries = entries.ToArray();
            return graph;
        }
    }
}
