using System.IO;
using System.Linq;

namespace ModLoader
{
    public class Module : Unit<Module>
    {
        public Pack Parent { get; }

        public Stream Data { get; }

        public override Module Fallback { get => Parent.Fallback.Members.Single(m => m.Name == Name); set => throw new System.NotImplementedException(); }

        private bool _enabled = true;
        public override bool Enabled { get => Parent.Enabled && _enabled; set => _enabled = value; }

        public Module(Pack parent, string name) : base(name)
        {
            Parent = parent;
            Data = Parent.Archive.GetEntry(name).Open();
        }
    }
}
