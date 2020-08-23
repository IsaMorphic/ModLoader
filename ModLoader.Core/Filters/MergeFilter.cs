using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

    public class MergeFilter<T> : GroupFilter<T>
        where T : class, IMergeable<T>
    {
        class MergingUnit
        {
            public T Unit { get; }
            public HashSet<MergingUnit> Mergers { get; set; }

            public MergingUnit(T unit)
            {
                Unit = unit;
                Mergers = new HashSet<MergingUnit>();
            }
        }

        public override IGroup<T> Apply(IGroup<T> group)
        {
            HashSet<MergingUnit> units =
                new HashSet<MergingUnit>(group.Members
                    .Select(m => new MergingUnit(m.ResolveSelf()))
                    );

            foreach (var thisUnit in units)
            {
                foreach (var otherUnit in units)
                {
                    if (thisUnit != otherUnit && thisUnit.Unit.CanMergeWith(otherUnit.Unit))
                    {
                        thisUnit.Mergers.Add(otherUnit);
                        otherUnit.Mergers.Add(thisUnit);
                    }
                }
            }

            HashSet<IResolvable<T>> merged =
                new HashSet<IResolvable<T>>(units
                .Where(u => !u.Mergers.Any())
                .Select(u => u.Unit)
                );

            HashSet<MergingUnit> instigators = new HashSet<MergingUnit>();

            foreach (var thisUnit in units.Where(u => u.Mergers.Any()))
            {
                var members = thisUnit.Mergers
                    .Except(instigators.Concat(instigators.SelectMany(u => u.Mergers)).Distinct())
                    .Select(u => u.Unit);

                if (members.Any())
                {
                    var merger = thisUnit.Unit.MergeWith(new HashSet<T>(members));
                    instigators.Add(thisUnit);
                    merged.Add(merger);
                }
            }

            return new Group<T>(new HashSet<IResolvable<T>>(merged));
        }
    }
}
