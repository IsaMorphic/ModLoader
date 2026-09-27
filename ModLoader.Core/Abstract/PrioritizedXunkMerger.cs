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

            var groups = Mergers
                .Select(m => new { Priority = m.GetPriorityOver(@base), Group = (XunkGroup<T>)m.Inner })
                .SelectMany(k => k.Group.Xunks.Select(x => new { Priority = k.Priority, Xunk = x.ResolveSelf() }))
                .GroupBy(l => l.Xunk.MergeKey)
                .Select(g => g.GroupBy(x => x.Priority).MaxBy(x => x.Key).Select(x => x.Xunk));

            var resolved = new HashSet<IPotential<T>>();
            foreach (var group in groups) 
            {
                var instigator = group.First();
                var mergers = group.Skip(1);

                if (mergers.Any())
                {
                    resolved.Add(new Conflict<T>(instigator.ToString(), instigator, new HashSet<IResolvable<T>>(mergers)));
                }
                else 
                {
                    resolved.Add(instigator);
                }
            }

            return new XunkGroup<T>(Parent, Base?.Name ?? "[ERROR: UNRESOLVED]", Base, new HashSet<IPotential<T>>(resolved));
        }
    }
}
