using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader
{
    public class Module : Unit<Module>
    {
        public Pack Parent { get; }

        public Stream Data { get; }

        public override Unit<Module> Fallback => 
            Parent.Fallback.Resolve().Members
            .Single(m => m.Name == Name);

        public override bool Enabled => Parent.Enabled;

        public Module(string name, Pack parent) : base(name)
        {
            Parent = parent;
        }

        public override bool ConflictsWith(Module other)
        {
            return Name == other.Name;
        }

        protected override Module ResolveSelf() => this;

        protected override Task LoadSelfAsync()
        {
            var path = Path.Combine("");
            Data.CopyToAsync();
        }
    }
}
