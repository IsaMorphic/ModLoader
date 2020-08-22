using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    public abstract class GroupMerger<T, U> : Merger<T>
        where T : Group<T, U>, new()
        where U : Unit<U>
    {
        public GroupMerger(string name, HashSet<T> mergers) : base(name, mergers)
        {
        }

        class MergingUnit
        {
            public U Unit { get; }
            public HashSet<MergingUnit> Resolvers { get; set; }
            public HashSet<MergingUnit> Mergers { get; set; }

            public MergingUnit(U unit)
            {
                Unit = unit;
                Resolvers = new HashSet<MergingUnit>();
                Mergers = new HashSet<MergingUnit>();
            }
        }

        protected override T ResolveSelf()
        {
            HashSet<MergingUnit> units =
                new HashSet<MergingUnit>(Mergers
                    .SelectMany(m => m.Members)
                    .Select(m => m.Resolve())
                    .Where(m => m != null)
                    .Distinct()
                    .Select(m => new MergingUnit(m))
                    );

            foreach (var thisUnit in units)
            {
                foreach (var otherUnit in units)
                {
                    if (thisUnit.Unit.ResolveFull().Contains(otherUnit.Unit))
                    {
                        otherUnit.Resolvers.Add(thisUnit);
                    }
                }
            }

            var filtered = units.Where(u => !u.Resolvers.Any());

            foreach (var thisUnit in filtered)
            {
                foreach (var otherUnit in filtered)
                {
                    if (thisUnit != otherUnit && thisUnit.Unit.CanMergeWith(otherUnit.Unit))
                    {
                        thisUnit.Mergers.Add(otherUnit);
                        otherUnit.Mergers.Add(thisUnit);
                    }
                }
            }

            HashSet<Unit<U>> merged =
                new HashSet<Unit<U>>(filtered
                .Where(u => !u.Mergers.Any())
                .Select(u => u.Unit)
                );

            HashSet<MergingUnit> instigators = new HashSet<MergingUnit>();

            foreach (var thisUnit in filtered.Where(u => u.Mergers.Any()))
            {
                var members = thisUnit.Mergers
                    .Except(instigators.Concat(instigators.SelectMany(u => u.Mergers)).Distinct())
                    .Select(u => u.Unit);

                var merger = thisUnit.Unit.MergeWith(new HashSet<U>(members));

                if (!merger.Empty())
                {
                    instigators.Add(thisUnit);
                    merged.Add(merger);
                }
            }

            var result = new T();
            result.Members.UnionWith(merged);

            return result;
        }
    }
}
