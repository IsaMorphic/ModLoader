namespace ModLoader.Core.Abstract
{
    public abstract class GroupFilter<TIn, TOut> : IPotential<IGroup<TOut>>
        where TIn : class
        where TOut : class
    {
        public IPotential<IGroup<TIn>> Input { get; }

        public GroupFilter(IPotential<IGroup<TIn>> input)
        {
            Input = input;
        }

        public IGroup<TOut> ResolveSelf()
        {
            return Apply(Input.ResolveSelf());
        }

        public abstract IGroup<TOut> Apply(IGroup<TIn> group);
    }
}
