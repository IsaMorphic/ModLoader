using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader
{
    public abstract class GroupMerger<T, U> : Merger<T>
        where T : Group<T, U>, new()
        where U : Unit<U>
    {
        public GroupMerger(string name, HashSet<T> mergers) : base(name, mergers)
        {
        }

        class ConflictedUnit
        {
            public U Unit { get; }
            public HashSet<ConflictedUnit> Conflictors { get; set; }

            public ConflictedUnit(U unit)
            {
                Unit = unit;
                Conflictors = new HashSet<ConflictedUnit>();
            }
        }

        public override bool ConflictsWith(T other) => throw new NotSupportedException();

        protected override T ResolveSelf()
        {
            HashSet<ConflictedUnit> modules = 
                new HashSet<ConflictedUnit>(Mergers
                    .SelectMany(m => m.Members)
                    .Select(m => m.Resolve())
                    .Where(m => m != null)
                    .Distinct()
                    .Select(m => new ConflictedUnit(m))
                    );

            foreach (var thisUnit in modules)
            {
                foreach (var otherUnit in modules.Where(u => u != thisUnit))
                {
                    if (thisUnit.Unit.ConflictsWith(otherUnit.Unit))
                    {
                        thisUnit.Conflictors.Add(otherUnit);
                        otherUnit.Conflictors.Add(thisUnit);
                    }
                }
            }

            HashSet<Unit<U>> merged = 
                new HashSet<Unit<U>>(modules
                .Where(u => !u.Conflictors.Any())
                .Select(u => u.Unit)
                );

            HashSet<ConflictedUnit> instigators = new HashSet<ConflictedUnit>();

            foreach (var thisUnit in modules.Where(u => u.Conflictors.Any()))
            {
                var members = thisUnit.Conflictors
                    .Except(instigators.Concat(instigators.SelectMany(u => u.Conflictors)).Distinct())
                    .Select(u => u.Unit);

                var conflict = new Conflict<U>(thisUnit.Unit, new HashSet<U>(members));

                if (!conflict.Empty()) 
                { 
                    instigators.Add(thisUnit);
                    merged.Add(conflict);
                }
            }

            var result = new T();
            result.Members.UnionWith(merged);

            return result;
        }

        protected override Task LoadSelfAsync() => throw new NotSupportedException();
    }
}
