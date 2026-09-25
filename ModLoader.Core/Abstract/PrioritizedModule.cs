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

        public override bool CanMergeWith(IResolvable<IResolvable<Module>> other)
        {
            return base.CanMergeWith(other) && Inner.ResolveFull().Contains((other as Prioritized<Module, string>).Inner);
        }

        public override int GetPriorityOver(Prioritized<Module, string> other)
        {
            return Inner.ResolveFull(inclusive: false)
                .FindIndex(m => m.ResolveSelf().Id == other.Inner.ResolveSelf().Id);
        }
    }
}
