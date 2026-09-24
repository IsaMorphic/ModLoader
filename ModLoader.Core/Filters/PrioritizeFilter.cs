using System;
using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

    public class PrioritizeFilter<T, U> : GroupFilter<IMergeable<T, U>, Prioritized<T, U>>
        where T : class
    {
        public PrioritizeFilter(IPotential<IGroup<IMergeable<T, U>>> input) : base(input)
        {
        }

        public override IGroup<Prioritized<T, U>> Apply(IGroup<IMergeable<T, U>> group)
        {
            var filtered = group.Members.Select(m => new Prioritized<T, U>(m));
            return new Group<Prioritized<T, U>>(filtered);
        }
    }
}
