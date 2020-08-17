using System;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    public class GhostModule : Module
    {
        public GhostModule(string name, Pack parent) : base(name, Guid.Empty, parent)
        {
        }

        protected override Module ResolveSelf()
        {
            return Parent
                .ResolveAsIfDisabled()?.Members
                .SingleOrDefault(m => m.Name == Name)
                ?.Resolve();
        }

        protected override Task LoadSelfAsync()
        {
            throw new NotSupportedException();
        }
    }
}
