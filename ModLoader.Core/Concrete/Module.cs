namespace ModLoader.Core
{
    using Abstract;

    public class Module : ILoadable<Module>, IMergeable<Module, string>
    {
        public Guid Id { get; }

        public string Name { get; }

        public IPackBase Parent { get; }
        public Game Root { get; }

        public IResolvable<Module> Fallback
        {
            get
            {
                var resolved = Parent.Fallback as IPackBase;
                if (resolved == null) return null;
                else return resolved.Members.ContainsKey(Name) ? 
                        resolved.Members[Name] : new GhostModule(resolved, Name);
            }
        }

        public bool Enabled { get; set; }

        bool IResolvable<Module>.Enabled => Enabled && ((Parent as IResolvable<Pack>)?.Enabled ?? true);

        public string MergeKey => Name;

        public Module(IPackBase parent, string name, Guid id)
        {
            Id = id;
            Name = name;

            Parent = parent;
            Root = Parent?.Parent;

            Enabled = true;
        }

        public virtual Module ResolveSelf() => this;

        public virtual IPotential<Module> MergeWith(HashSet<IResolvable<Module>> others)
        {
            return new Conflict<Module>(Name, this, others);
        }

        public virtual Stream GetDataStream()
        {
            return Parent.GetStream(Name);
        }

        public virtual async Task LoadSelfAsync()
        {
            if (!Root.Graph.Entries.ContainsKey(Name))
            {
                Root.Graph.Entries.Add(Name, Guid.Empty);
            }

            if (Root.Graph.Entries[Name] == Id) return;

            var file = await Root.Files.StageFileAsync(Name);
            try
            {
                await Root.BasePack.CopyModuleAsync(Name);

                using (var data = GetDataStream())
                {
                    await data.CopyToAsync(file.Stream);
                }

                await Root.Files.CommitFileAsync(file);

                if (Root.BasePack.Graph.Entries.TryGetValue(Name, out Guid id) && id == Id) 
                {
                    await Root.BasePack.RemoveModuleAsync(Name);
                }

                Root.Graph.Entries[Name] = Id;
            }
            catch (Exception)
            {
                await Root.Files.UnstageFileAsync(file);
                throw;
            }
        }

        public override string ToString()
        {
            return $"({Parent}) {Name}";
        }
    }
}
