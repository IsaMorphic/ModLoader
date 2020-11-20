using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

    public class StackFilter : GroupFilter<Module, Module>
    {
        public StackFilter(IPotential<IGroup<Module>> input) : base(input)
        {
        }

        public override IGroup<Module> Apply(IGroup<Module> group)
        {
            var filtered = group.Members
                .Where(m => !group.Members
                    .Where(n => n.ResolveFull(false).Contains(m))
                .Any());

            return new Group<Module>(filtered);
        }
    }
}
