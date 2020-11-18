using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

    public class PrioritizeFilter<T> : GroupFilter<IMergeable<T>, Prioritized<T>>
        where T : class
    {
        public PrioritizeFilter(IPotential<IGroup<IMergeable<T>>> input) : base(input)
        {
        }

        public override IGroup<Prioritized<T>> Apply(IGroup<IMergeable<T>> group)
        {
            var filtered = group.Members.Select(m => new Prioritized<T>(m, 0));
            return new Group<Prioritized<T>>(filtered);
        }
    }
}
