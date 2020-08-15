using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    .Select(m => new ConflictedUnit(m))
                    );

            HashSet<ConflictedUnit> instigators = new HashSet<ConflictedUnit>();

            HashSet<Unit<U>> merged = new HashSet<Unit<U>>();

            foreach (var thisUnit in modules)
            {
                Conflict<U> conflict = new Conflict<U>(thisUnit.Unit);

                foreach (var otherUnit in modules.Where(u => !u.Conflictors.Contains(thisUnit) && u != thisUnit))
                {
                    if (thisUnit.Unit.ConflictsWith(otherUnit.Unit))
                    {
                        thisUnit.Conflictors.Add(otherUnit);
                        otherUnit.Conflictors.Add(thisUnit);

                        conflict.Mergers.Add(otherUnit.Unit);
                    }
                }

                if (!thisUnit.Conflictors.Intersect(instigators).Any())
                {
                    if (conflict.Empty())
                        merged.Add(thisUnit.Unit);
                    else
                    {
                        instigators.Add(thisUnit);
                        merged.Add(conflict);
                    }
                }
            }

            var result = new T();
            result.Members.UnionWith(merged);

            return result;
        }

        protected override Task LoadSelfAsync() => throw new NotSupportedException();
    }
}
