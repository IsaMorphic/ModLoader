using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Abstract
{
    using Filters;

    public class PrioritizedXunkMerger<T> : IPotential<Module>
        where T : Xunk<T>
    {
        public Module Base { get; }
        public Pack Parent { get; }

        public HashSet<Prioritized<Module>> Mergers { get; }

        public PrioritizedXunkMerger(Pack parent, Module @base, HashSet<Prioritized<Module>> mergers)
        {
            Base = @base;
            Parent = parent;

            Mergers = mergers;
        }

        public Module ResolveSelf()
        {
            var group = Mergers
                .SelectMany(m => (m.ResolveSelf() as XunkGroup<T>).Xunks
                    .Select(x => new Prioritized<T>(x.ResolveSelf(), m.Priority))
                    );

            var resolver = new MergeFilter<T>(
                new PotentialFilter<T>(
                    new PriorityFilter<T>(
                        new MergeFilter<IResolvable<T>>(
                            new TrivialPotential<IGroup<Prioritized<T>>>(
                                new Group<Prioritized<T>>(group)
                                )
                            )
                        )
                    )
                );
            var resolved = resolver.ResolveSelf().Members;

            return new XunkGroup<T>(Parent, Base?.Name ?? "[ERROR: UNRESOLVED]", Base, new HashSet<IPotential<T>>(resolved));
        }
    }
}
