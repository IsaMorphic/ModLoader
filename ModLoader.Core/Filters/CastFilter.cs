using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

    public class CastFilter<TIn, TOut> : GroupFilter<TIn, TOut>
        where TIn : class
        where TOut : class
    {
        public override IGroup<TOut> Apply(IGroup<TIn> group)
        {
            var filtered = group.Members.Cast<TOut>();
            return new Group<TOut>(new HashSet<TOut>(filtered));
        }
    }
}
