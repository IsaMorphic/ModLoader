using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

    public class PrioritizeFilter<T> : GroupFilter<IResolvable<T>, IResolvable<IResolvable<T>>>
        where T : class
    {
        public override IGroup<IResolvable<IResolvable<T>>> Apply(IGroup<IResolvable<T>> group)
        {
            var filtered = group.Members.Select(m => new Prioritized<T>(m, 0));
            return new Group<IResolvable<IResolvable<T>>>(new HashSet<IResolvable<IResolvable<T>>>(filtered));
        }
    }
}
