using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                var resolved = Parent.Fallback as Pack;
                if (resolved == null) return null;
                else return resolved.Members
                        .SingleOrDefault(m => m.Name == Name) ??
                        new GhostModule(resolved, Name);
            }
        }

        public bool Enabled { get; set; }

        bool IResolvable<Module>.Enabled => Enabled && ((Parent as IResolvable<Pack>)?.Enabled ?? true);

        public Module(Pack parent, string name, Guid id)
        {
            Id = id;
            Name = name;

            Parent = parent;
            Root = Parent?.Parent;

            Enabled = true;
        }

        public virtual Module ResolveSelf() => this;

        public virtual bool CanMergeWith(IResolvable<Module> other)
        {
            return Name == (other as Module).Name;
        }

        public virtual IPotential<Module> MergeWith(HashSet<IResolvable<Module>> others)
        {
            return new Conflict<Module>(Name, this, others);
        }

        public virtual Stream GetDataStream()
        {
            return Parent.Archive.GetEntry(Name).Open();
        }

        public virtual async Task LoadSelfAsync()
        {
            if (!Root.Graph.Table.ContainsKey(Name))
            {
                Root.Graph.Table.Add(Name, Guid.Empty);
            }

            if (Root.Graph.Table[Name] == Id) return;

            var file = await Root.Files.StageFileAsync(Name);
            try
            {
                using (var data = GetDataStream())
                {
                    await data.CopyToAsync(file.Stream);
                }

                await Root.Files.CommitFileAsync(file);

                Root.Graph.Table[Name] = Id;
            }
            catch (Exception ex)
            {
                await Root.Files.UnstageFileAsync(file);
                throw ex;
            }
        }

        public override string ToString()
        {
            return $"({Parent}) {Name}";
        }
    }
}
