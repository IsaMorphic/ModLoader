using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    public class Module : Unit<Module>
    {
        public Guid Id { get; }

        public Pack Parent { get; }
        public PackGroup Root { get; }

        public Stream Data { get; private set; }

        public override Unit<Module> Fallback
        {
            get
            {
                var resolved = Parent.ResolveAsIfDisabled();
                if (resolved == null) return null;
                else return resolved.Members
                        .SingleOrDefault(m => m.Name == Name) ?? 
                        new GhostModule(Name, resolved);
            }
        }

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
        }

        public Task InitializeAsync()
        {
            return Task.Run(() => Data = Parent.Archive.GetEntry(Name).Open());
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
