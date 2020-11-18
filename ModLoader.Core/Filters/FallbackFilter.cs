using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

    public class FallbackFilter<T> : GroupFilter<IResolvable<T>, IResolvable<T>>
        where T : class
    {
        public override IGroup<IResolvable<T>> Apply(IGroup<IResolvable<T>> group)
        {
            var filtered = group.Members
                .SelectMany(m => m.ResolveFull());
            return new Group<IResolvable<T>>(new HashSet<IResolvable<T>>(filtered));
        }
    }
}
