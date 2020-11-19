using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

    public class PotentialFilter<T> : GroupFilter<IPotential<T>, T>
        where T : class
    {
        public PotentialFilter(IPotential<IGroup<IPotential<T>>> input) : base(input)
        {
        }

        public override IGroup<T> Apply(IGroup<IPotential<T>> group)
        {
            var filtered = group.Members.Select(m => m.ResolveSelf());
            return new Group<T>(filtered);
        }
    }
}
