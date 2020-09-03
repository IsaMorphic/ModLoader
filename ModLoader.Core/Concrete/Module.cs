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

        public bool Enabled { get; set; }

        bool IResolvable<Module>.Enabled => Enabled && (Parent as IResolvable<Pack>).Enabled;

        public Module(Pack parent, string name, Guid id)
        {
            Id = id;
            Name = name;

            Parent = parent;
            Root = Parent.Parent;

            Enabled = true;
        }

        public virtual Module ResolveSelf() => this;

        public virtual bool CanMergeWith(Module other)
        {
            return Name == other.Name;
        }

        public virtual IResolvable<Module> MergeWith(HashSet<Module> others)
        {
            return new Conflict<Module>(Name, this, others);
        }

        public virtual Stream GetDataStream()
        {
            return Parent.Archive.GetEntry(Name).Open();
        }

        public virtual async Task LoadSelfAsync(CancellationToken token)
        {
            if (!Root.Graph.Table.ContainsKey(Name))
            {
                Root.Graph.Table.Add(Name, new HashSet<Guid>());
            }

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
