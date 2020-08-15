using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader
{
    public class Module : Unit<Module>
    {
        public Guid Id { get; }

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

        public Module(string name, Guid id, Pack parent) : base(name)
        {
            Id = id;

            Parent = parent;
            Root = Parent.Parent;

            Data = Parent.Archive.GetEntry(Name).Open();
        }

        public override bool ConflictsWith(Module other)
        {
            return Name == other.Name;
        }

        protected override Module ResolveSelf() => this;

        protected override async Task LoadSelfAsync()
        {
            if (Root.Graph.Table[Name] == Id) return;

            var path = Path.Combine(Root.GamePath, Name);

            using (var stream = File.Create(path))
                await Data.CopyToAsync(stream);

            Root.Graph.Table[Name] = Id;
        }

        public override string ToString()
        {
            return $"({Parent}) {Name}";
        }
    }
}
