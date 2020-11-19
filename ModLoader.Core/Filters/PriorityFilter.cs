using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

    public class PriorityFilter<T> : GroupFilter<IPotential<IResolvable<T>>, IResolvable<T>>
        where T : class
    {
        public PriorityFilter(IPotential<IGroup<IPotential<IResolvable<T>>>> input) : base(input)
        {
        }

        public override IGroup<IResolvable<T>> Apply(IGroup<IPotential<IResolvable<T>>> group)
        {
            var filtered = group.Members
                .Where(m => m is PrioritizedConflict<T>)
                .Cast<PrioritizedConflict<T>>()
                .SelectMany(m => m.Members)
                .Concat(group.Members
                    .Where(m => !(m is PrioritizedConflict<T>))
                    .Select(m => m.ResolveSelf())
                    );

            return new Group<IResolvable<T>>(filtered);
        }
    }
}
