using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

    public class PriorityFilter<T> : GroupFilter<IPotential<IResolvable<T>>, IResolvable<T>>
        where T : class
    {
        public PriorityFilter(IPotential<IGroup<IPotential<IResolvable<T>>>> input) : base(input)
        {
        }

        public override IGroup<IResolvable<T>> Apply(IGroup<IPotential<IResolvable<T>>> group)
        {
            var filtered = group.Members
                .Cast<PrioritizedConflict<T>>()
                .SelectMany(m => m.Members);

            return new Group<IResolvable<T>>(filtered);
        }
    }
}
