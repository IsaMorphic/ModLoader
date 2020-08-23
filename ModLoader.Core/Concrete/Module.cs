using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Abstract;

    public class Module : ILoadable<Module>, IMergeable<Module>
    {
        public Guid Id { get; }

        public string Name { get; }

        public Pack Parent { get; }
        public Game Root { get; }

        public IResolvable<Module> Fallback
        {
            get
            {
                var resolved = Parent.ResolveAsIfDisabled();
                if (resolved == null) return null;
                else return resolved.Members
                        .SingleOrDefault(m => m.Resolve()?.Name == Name) ??
                        new GhostModule(resolved, Name);
            }
        }

        private bool _enabled = true;
        public bool Enabled
        {
            get => _enabled && Parent.Enabled;
            set => _enabled = value;
        }

        public Module(Pack parent, string name, Guid id)
        {
            Id = id;
            Name = name;

            Parent = parent;
            Root = Parent.Parent;
        }

        public virtual Module ResolveSelf() => this;

        public virtual bool CanMergeWith(Module other)
        {
            return Name == other.Name;
        }

        public virtual IResolvable<Module> MergeWith(HashSet<Module> others)
        {
            return new Conflict<Module>(this, others);
        }

        public virtual Stream GetDataStream()
        {
            return Parent.Archive.GetEntry(Name).Open();
        }

        public virtual async Task LoadSelfAsync(CancellationToken token)
        {
            try
            {
                if (Root.Graph.Table[Name].Single() == Id) return;
            }
            catch (InvalidOperationException) { }

            var path = Path.Combine(Root.GamePath, Name);

            Directory.CreateDirectory(Path.GetDirectoryName(path));

            using (var data = GetDataStream())
            using (var stream = File.Create(path))
            {
                await data.CopyToAsync(stream);
            }

            Root.Graph.Table[Name] = new HashSet<Guid> { Id };
        }

        public override string ToString()
        {
            return $"({Parent}) {Name}";
        }
    }
}
