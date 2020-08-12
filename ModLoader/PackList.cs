using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader
{
    public class PackList : Unit
    {
        public string BaseDirectory { get; }

        public PackList() : base(null, "_packlist_")
        {
        }

        public Dictionary<string, Pack> Packs { get; }

        public List<Conflict> GetConflicts()
        {
            List<string> uniqueModules = Packs.Values
                .SelectMany(pack => pack.Modules.Keys)
                .Distinct()
                .ToList();

            List<Conflict> conflicts = new List<Conflict>();

            foreach (var m in uniqueModules)
            {
                var givenModules = Packs.Values.Select(pack => pack.Modules[m]);
                foreach (var n in givenModules)
                {
                    foreach (var o in givenModules)
                    {
                         // TODO: Finish this method
                    }
                }
            }
        }

        public override Task Load()
        {
            throw new NotImplementedException();
        }
    }
}
