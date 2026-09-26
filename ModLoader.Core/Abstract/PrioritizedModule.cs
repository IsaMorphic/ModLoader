using System;
using System.Collections.Generic;

namespace ModLoader.Core.Abstract
{
    public class PrioritizedModule : Prioritized<Module, string>
    {
        public PrioritizedModule(IMergeable<Module, string> inner) : base(inner)
        {
        }

        protected override Prioritized<Module, string> GetFallbackCore()
        {
            return Inner.Fallback == null ? null : new PrioritizedModule(Inner.Fallback.ResolveSelf());
        }

        public override IPotential<IResolvable<Module>> MergeWith(HashSet<IResolvable<IResolvable<Module>>> others)
        {
            if (Inner.ResolveSelf() is not Diff and not Patch)
            {
                others.Add(this);
            }

            return base.MergeWith(others);
        }

        public override int GetPriorityOver(Prioritized<Module, string> other)
        {
            Guid otherId = other.Inner.ResolveSelf().Id;
            int thisPriority = Inner.ResolveFull()
                .FindIndex(m => m.ResolveSelf()?.Id == otherId);

            Guid thisId = Inner.ResolveSelf().Id;
            int otherPriority = other.Inner.ResolveFull()
                .FindIndex(m => m.ResolveSelf()?.Id == thisId);

            if (thisPriority < 0 && otherPriority < 0)
            {
                return 0;
            }
            else if (thisPriority < 0)
            {
                return -otherPriority;
            }
            else 
            {
                return thisPriority;
            }
        }
    }
}
