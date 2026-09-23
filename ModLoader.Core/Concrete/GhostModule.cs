using System;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Abstract;
    using Exceptions;

    public class GhostModule : Module
    {
        public GhostModule(IPackBase parent, string name) : base(parent, name, Guid.Empty)
        {
        }

        public override Module ResolveSelf()
        {
            var resolved = Parent.ResolveAsIfDisabled();
            if (resolved == null) return null;
            else return resolved.Members.ContainsKey(Name) ?
                    resolved.Members[Name].Resolve() : null;
        }

        public override Task LoadSelfAsync()
        {
            throw new GhostedModuleException("An attempt was made to directly load a ghosted module reference.\nThis is a bug, please contact the developers so that the issue may be resolved.\n\"oh my god.... did I break it again?\" ~IsaMorphic");
        }
    }
}
