using System;
using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

    public class WhereFilter<T> : GroupFilter<T, T>
        where T : class
    {
        private Func<T, bool> Predicate { get; }

        public WhereFilter(IPotential<IGroup<T>> input, Func<T, bool> predicate) : base(input)
        {
            Predicate = predicate;
        }

        public override IGroup<T> Apply(IGroup<T> group)
        {
            var filtered = group.Members.Where(Predicate);
            return new Group<T>(filtered);
        }
    }
}
