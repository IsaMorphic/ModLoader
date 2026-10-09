namespace ModLoader.Core.Abstract
{
    public interface IPackBase : IGroup<Module>, ILoadable<IPackBase>
    {
        Guid Id { get; }

        string Name { get; }

        Game Parent { get; }

        bool IsArchive { get; }

        new IDictionary<string, Module> Members { get; }

        Stream GetStream(string name);

        Task InitializeAsync();
    }
}
