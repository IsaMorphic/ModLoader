using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Abstract
{
    using Filters;

    public class PrioritizedXunkMerger<T> : IPotential<Module>
        where T : Xunk<T>
    {
        public Module Base { get; }
        public IPackBase Parent { get; }

        public HashSet<Prioritized<Module, string>> Mergers { get; }

        public PrioritizedXunkMerger(IPackBase parent, Module @base, HashSet<Prioritized<Module, string>> mergers)
        {
            Base = @base;
            Parent = parent;

            Mergers = mergers;
        }

        public Module ResolveSelf()
        {
            var resolved = new PriorityFilter<T>(
                new MergeFilter<IResolvable<T>, XunkKey>(
                        new PrioritizeXunkFilter<T>(
                            new PotentialFilter<T>(
                                new TrivialPotential<IGroup<IPotential<T>>>(
                                    new Group<IPotential<T>>(Mergers.SelectMany(m => (m.Inner as XunkGroup<T>)?.Xunks ?? [])
                                    )
                                )
                            )
                        )
                    )
                );

            return new XunkGroup<T>(Parent, Base?.Name ?? "[ERROR: UNRESOLVED]", Base, 
                resolved.ResolveSelf().Members.ToHashSet<IPotential<T>>());
        }
    }
}
