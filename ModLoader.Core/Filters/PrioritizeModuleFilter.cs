using System.Linq;

namespace ModLoader.Core.Filters
{
    using Abstract;

    public class PrioritizeModuleFilter : GroupFilter<IMergeable<Module, string>, Prioritized<Module, string>>
    {
        public PrioritizeModuleFilter(IPotential<IGroup<IMergeable<Module, string>>> input) : base(input)
        {
        }

        public override IGroup<Prioritized<Module, string>> Apply(IGroup<IMergeable<Module, string>> group)
        {
            var filtered = group.Members.Select(m => new PrioritizedModule(m));
            return new Group<Prioritized<Module, string>>(filtered);
        }
    }
}
