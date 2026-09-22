using System;
using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

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
                    .Cast<Prioritized<Module, string>>()
                    );
            var filtered = resolved
                .Select(g => (a: g.Select(m => m.ResolveSelf()), b: g.TakeWhile(r => r.ResolveSelf().GetType() != typeof(Module))))
                .Where(x => x.b.Any())
                .Select(x => new PrioritizedXunkMerger<T>( 
                    (x.b.First().ResolveSelf() as Module).Parent,                                                   // Evil code.  Here's a summary.
                    x.a.TakeWhile(m => m.GetType() != typeof(Module))                                               // If there's a burn module directly under a diff/patch
                    .Any(m => m.GetType() == typeof(Burn)) ?                                                        // .................
                    throw new InvalidOperationException("Death is upon those who burn a file below a diff/patch") : // Throw an error cause that's bad.
                    x.a.FirstOrDefault(m => m.GetType() == typeof(Module)) as Module,                               // otherwise use the closest non-diff/patch ancestor as  
                    new HashSet<Prioritized<Module, string>>(x.b.Where(m => !(m.ResolveSelf() is GhostModule)))     // the base of the merger.  
                    ));

            return new Group<IPotential<Module>>(filtered);
        }
    }
}
