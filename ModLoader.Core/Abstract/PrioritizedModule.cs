namespace ModLoader.Core.Abstract
{
    public class PrioritizedModule : Prioritized<Module>
    {
        public PrioritizedModule(IMergeable<Module> inner, int priority) : base(inner, priority)
        {
        }

        public override bool CanMergeWith(IResolvable<IResolvable<Module>> other)
        {
            return base.CanMergeWith(other) && Inner.ResolveFull().Contains((other as Prioritized<Module>).Inner);
        }
    }
}
