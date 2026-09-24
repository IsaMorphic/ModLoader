namespace ModLoader.Core.Abstract
{
    public class PrioritizedModule : Prioritized<Module, string>
    {
        public PrioritizedModule(IMergeable<Module, string> inner) : base(inner)
        {
        }

        public override bool CanMergeWith(IResolvable<IResolvable<Module>> other)
        {
            return base.CanMergeWith(other) && Inner.ResolveFull().Contains((other as Prioritized<Module, string>).Inner);
        }
    }
}
