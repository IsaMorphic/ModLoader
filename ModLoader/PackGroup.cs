using System;
using System.Collections.Generic;
using System.Linq;

namespace ModLoader
{
    public class PackGroup : Merger<Pack>
    {
        public string BaseDirectory { get; }

        public override Pack Fallback { get => null; set => throw new NotImplementedException(); }
        public override bool Enabled { get => true; set => throw new NotImplementedException(); }

        public PackGroup(HashSet<Pack> packs) : base("_packgroup_", packs)
        {
        }

        class ConflictedModule
        {
            public Module Module { get; }
            public HashSet<Module> Conflictors { get; set; }

            public ConflictedModule(Module module)
            {
                Module = module;
                Conflictors = new HashSet<Module>();
            }
        }

        public override Pack Resolve()
        {
            HashSet<ConflictedModule> modules =
                new HashSet<ConflictedModule>(Mergers
                    .SelectMany(m => m.Members)
                    .Select(m => m.Resolve())
                    .Where(m => m != null)
                    .Select(m => new ConflictedModule(m))
                    );

            HashSet<Module> merged = new HashSet<Module>();

            HashSet<Conflict<Module>> conflicts = new HashSet<Conflict<Module>>();

            foreach (var thisUnit in modules)
            {
                Conflict<Module> conflict = new Conflict<Module>(thisUnit.Module.Name, 
                    new HashSet<Module> { thisUnit.Module });

                foreach (var otherUnit in modules.Where(u => !u.Conflictors.Contains(thisUnit.Module)))
                {
                    if (thisUnit.Module.ConflictsWith(otherUnit.Module))
                    {
                        thisUnit.Conflictors.Add(otherUnit.Module);
                        otherUnit.Conflictors.Add(thisUnit.Module);

                        conflict.Mergers.Add(otherUnit.Module);
                    }
                }

                if (conflict.Mergers.Count > 1)
                    conflicts.Add(conflict);
                else
                    merged.Add(thisUnit.Module);
            }

            if (conflicts.Any())
                throw new ConflictException<Module>(conflicts);
            else
                return new Pack("_merged_", merged);
        }
    }
}
