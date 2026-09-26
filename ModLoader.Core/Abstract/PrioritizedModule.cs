using System;

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

        public override int GetPriorityOver(Prioritized<Module, string> other)
        {
            Guid otherId = other.Inner.ResolveSelf().Id;
            int thisPriority = Inner.ResolveFull()
                .FindIndex(m => m.ResolveSelf().Id == otherId);

            Guid thisId = Inner.ResolveSelf().Id;
            int otherPriority = other.Inner.ResolveFull()
                .FindIndex(m => m.ResolveSelf().Id == thisId);

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
