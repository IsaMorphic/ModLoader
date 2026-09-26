using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Abstract
{
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
            var @base = new PrioritizedModule(Base);

            var resolved = Mergers
                .Select(m => new { Priority = m.GetPriorityOver(@base), Group = (XunkGroup<T>)m.Inner })
                .SelectMany(k => k.Group.Xunks.Select(x => new { Priority = k.Priority, Xunk = x.ResolveSelf() }))
                .GroupBy(l => l.Xunk.MergeKey)
                .Select(g => g.MaxBy(x => x.Priority).Xunk);

            return new XunkGroup<T>(Parent, Base?.Name ?? "[ERROR: UNRESOLVED]", Base, new HashSet<IPotential<T>>(resolved));
        }
    }
}
