using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

    public class ResolveFilter<T> : GroupFilter<IResolvable<T>, T>
        where T : class
    {
        public override IGroup<T> Apply(IGroup<IResolvable<T>> group)
        {
            var filtered = group.Members
                .Select(m => m.Resolve())
                .Where(m => m != null);
            return new Group<T>(new HashSet<T>(filtered));
        }
    }
}
