using System;
using System.Threading.Tasks;

namespace ModLoader
{
    public class Patch : Module
    {
        public Patch(Pack parent, string name) : base(parent, name)
        {
        }

        public override Task Load()
        {
            throw new NotImplementedException();
        }
    }
}
