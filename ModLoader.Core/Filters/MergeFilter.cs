using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

    public class MergeFilter<T> : GroupFilter<IMergeable<T>, IPotential<T>>
        where T : class
    {
        public MergeFilter(IPotential<IGroup<IMergeable<T>>> input) : base(input)
        {
        }

        class MergingUnit
        {
            public IMergeable<T> Unit { get; }
            public HashSet<MergingUnit> Mergers { get; set; }

            public MergingUnit(IMergeable<T> unit)
            {
                Unit = unit;
                Mergers = new HashSet<MergingUnit>();
            }
        }

        public override IGroup<IPotential<T>> Apply(IGroup<IMergeable<T>> group)
        {
            HashSet<MergingUnit> units =
                new HashSet<MergingUnit>(group.Members
                    .Select(m => new MergingUnit(m))
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

            HashSet<IPotential<T>> merged =
                new HashSet<IPotential<T>>(units
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
                    var merger = thisUnit.Unit.MergeWith(new HashSet<IResolvable<T>>(members));
                    instigators.Add(thisUnit);
                    merged.Add(merger);
                }
            }

            return new Group<IPotential<T>>(merged);
        }
    }
}
