using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModLoader.Core.Concrete
{
    using Abstract;

    public class ComboPack : IResolvable<Pack>
    {
        public IResolvable<Pack> Fallback => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public Pack ResolveSelf()
        {
            throw new NotImplementedException();
        }
    }
}
