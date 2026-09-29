namespace ModLoader.Core.Abstract
{
    public class PrioritizedXunk<T> : Prioritized<T, XunkKey>
        where T : Xunk<T>
    {
        public PrioritizedXunk(IMergeable<T, XunkKey> inner) : base(inner)
        {
        }

        protected override Prioritized<T, XunkKey> GetFallbackCore()
        {
            return Inner.Fallback == null ? null : new PrioritizedXunk<T>(Inner.Fallback.ResolveSelf());
        }

        public override int GetPriorityOver(Prioritized<T, XunkKey> other)
        {
            PrioritizedModule thisParent = new PrioritizedModule(Inner.ResolveSelf().Parent);
            PrioritizedModule otherParent = new PrioritizedModule(other.Inner.ResolveSelf().Parent);
            return thisParent.GetPriorityOver(otherParent);
        }
    }
}
