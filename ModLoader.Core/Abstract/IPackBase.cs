using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ModLoader.Core.Abstract
{
    public interface IPackBase : IGroup<Module>, ILoadable<IPackBase>
    {
        Guid Id { get; }

        string Name { get; }

        Game Parent { get; }

        new IDictionary<string, Module> Members { get; }

        Stream GetStream(string name);

        Task InitializeAsync(int dependencyLevel = 0);
    }
}
