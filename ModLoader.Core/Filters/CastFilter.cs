using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

    public class CastFilter<TIn, TOut> : GroupFilter<TIn, TOut>
        where TIn : class
        where TOut : class
    {
        public CastFilter(IPotential<IGroup<TIn>> input) : base(input)
        {
        }

        public override IGroup<TOut> Apply(IGroup<TIn> group)
        {
            var filtered = group.Members.Cast<TOut>();
            return new Group<TOut>(filtered);
        }
    }
}
