using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModLoader
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
