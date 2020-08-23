namespace ModLoader.Core.Abstract
{
    public abstract class GroupFilter<T> : IResolvable<IGroup<T>>
        where T : class
    {
        public IResolvable<IGroup<T>> Fallback { get; set; }
        public bool Enabled { get; set; }

        public GroupFilter()
        {
            Enabled = true;
        }

        public IGroup<T> ResolveSelf()
        {
            return Apply(this.ResolveAsIfDisabled());
        }

        public abstract IGroup<T> Apply(IGroup<T> group);
    }
}
