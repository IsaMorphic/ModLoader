using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

    public class FallbackFilter<T> : GroupFilter<T>
        where T : class, IResolvable<T>
    {
        public override IGroup<T> Apply(IGroup<T> group)
        {
            var filtered = group.Members
                .Where(m => !group.Members
                    .Where(n => n.ResolveFull().Contains(m))
                .Any());

            return new Group<T>(new HashSet<IResolvable<T>>(filtered));
        }
    }
}
