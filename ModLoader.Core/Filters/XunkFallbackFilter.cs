using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;
    using System.Collections.Generic;

    public class XunkFallbackFilter<T> : GroupFilter<IResolvable<IResolvable<Module>>, IPotential<Module>>
        where T : Xunk<T>
    {
        public XunkFallbackFilter(IPotential<IGroup<IResolvable<IResolvable<Module>>>> input) : base(input)
        {
        }

        public override IGroup<IPotential<Module>> Apply(IGroup<IResolvable<IResolvable<Module>>> group)
        {
            var resolved = group.Members
                .Select(m => m.ResolveFull()
                    .Cast<Prioritized<Module>>()
                    );
            var filtered = resolved
                .Select(g => (a: g.Select(m => m.ResolveSelf()), b: g.TakeWhile(r => r.ResolveSelf().GetType() != typeof(Module))))
                .Where(x => x.b.Any())
                .Select(x => new PrioritizedXunkMerger<T>(
                    (x.b.First().ResolveSelf() as Module).Parent,
                    x.a.First(m => m.GetType() == typeof(Module)) as Module,
                    new HashSet<Prioritized<Module>>(x.b)
                    ));

            return new Group<IPotential<Module>>(filtered);
        }
    }
}
