using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader
{
    public class Module : Unit<Module>
    {
        public Pack Parent { get; }
        public PackGroup Root { get; }

        public Stream Data { get; }

        public override Unit<Module> Fallback => 
            Parent.Fallback?.Resolve().Members
            .Single(m => m.Name == Name);

        public override bool Enabled 
        { 
            get => base.Enabled && Parent.Enabled; 
            set => base.Enabled = value; 
        }

        public Module(string name, Pack parent) : base(name)
        {
            Parent = parent;
            Root = Parent.Parent;

            Data = Parent.Archive.GetEntry(Name).Open();
        }

        public override bool ConflictsWith(Module other)
        {
            return Name == other.Name;
        }

        protected override Module ResolveSelf() => this;

        protected override Task LoadSelfAsync()
        {
            var path = Path.Combine(Root.GamePath, Name);
            return Data.CopyToAsync(File.OpenRead(path));
        }

        public override string ToString()
        {
            return $"({Parent}) {Name}";
        }
    }
}
