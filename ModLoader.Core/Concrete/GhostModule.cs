using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Abstract;
    using Exceptions;

    public class GhostModule : Module
    {
        public GhostModule(Pack parent, string name) : base(parent, name, Guid.Empty)
        {
        }

        public override Module ResolveSelf()
        {
            return Parent
                .ResolveAsIfDisabled()?.Members
                .Select(m => m.ResolveSelf())
                .SingleOrDefault(m => m.Name == Name)
                ?.Resolve();
        }

        public override Task LoadSelfAsync()
        {
            throw new GhostedModuleException("An attempt was made to directly load a ghosted module reference.\nThis is a bug, please contact the developers so that the issue may be resolved.\n\"oh my god.... did I break it again?\" ~Yodadude2003");
        }
    }
}
