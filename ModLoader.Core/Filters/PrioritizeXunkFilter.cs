namespace ModLoader.Core.Filters
{
    using Abstract;

    public class PrioritizeXunkFilter<T> : GroupFilter<IMergeable<T, XunkKey>, Prioritized<T, XunkKey>>
        where T : Xunk<T>
    {
        public PrioritizeXunkFilter(IPotential<IGroup<IMergeable<T, XunkKey>>> input) : base(input)
        {
        }

        public override IGroup<Prioritized<T, XunkKey>> Apply(IGroup<IMergeable<T, XunkKey>> group)
        {
            var filtered = group.Members.Select(x => new PrioritizedXunk<T>(x));
            return new Group<Prioritized<T, XunkKey>>(filtered);
        }
    }
}
