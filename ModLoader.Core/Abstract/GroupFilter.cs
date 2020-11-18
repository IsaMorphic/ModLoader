namespace ModLoader.Core.Abstract
{
    public abstract class GroupFilter<TIn, TOut> : IResolvable<IGroup<TOut>>
        where TIn : class
        where TOut : class
    {
        public IResolvable<IGroup<TOut>> Fallback { get; set; }
        public bool Enabled { get; set; }

        public IResolvable<IGroup<TIn>> Input { get; set; }

        public GroupFilter()
        {
            Enabled = true;
        }

        public IGroup<TOut> ResolveSelf()
        {
            return Apply(Input.Resolve());
        }

        public abstract IGroup<TOut> Apply(IGroup<TIn> group);
    }
}
