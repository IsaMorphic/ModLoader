using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

    public class MergeFilter<T, U> : GroupFilter<IMergeable<T, U>, IPotential<T>>
        where T : class
    {
        public MergeFilter(IPotential<IGroup<IMergeable<T, U>>> input) : base(input)
        {
        }

        public override IGroup<IPotential<T>> Apply(IGroup<IMergeable<T, U>> group)
        {
            var groups = new Dictionary<U, HashSet<IMergeable<T, U>>>();

            foreach (var member in group.Members)
            {
                if (!groups.ContainsKey(member.MergeKey))
                    groups.Add(member.MergeKey, new HashSet<IMergeable<T, U>> { member });
                else
                    groups[member.MergeKey].Add(member);
            }

            HashSet<IPotential<T>> merged = new HashSet<IPotential<T>>();
            foreach (var g in groups.Values)
            {
                var instigator = g.First();
                var mergers = g.Skip(1);

                if (mergers.Any())
                    merged.Add(instigator.MergeWith(mergers.Cast<IResolvable<T>>().ToHashSet()));
                else
                    merged.Add(instigator);
            }

            return new Group<IPotential<T>>(merged);
        }
    }
}
