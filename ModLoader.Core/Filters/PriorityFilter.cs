using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

    public class PriorityFilter<T> : GroupFilter<IResolvable<IResolvable<T>>, IResolvable<T>>
        where T : class
    {
        public override IGroup<IResolvable<T>> Apply(IGroup<IResolvable<IResolvable<T>>> group)
        {
            var filtered = group.Members
                .Cast<PrioritizedConflict<T>>()
                .OrderBy(m => m.Priority)
                .First().Members;

            return new Group<IResolvable<T>>(filtered);
        }
    }
}
