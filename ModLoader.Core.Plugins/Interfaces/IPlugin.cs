using System.Collections.Generic;

namespace ModLoader.Core.Plugins.Interfaces
{
    public interface IPlugin<T>
    {
        string Name { get; }

        string Author { get; }

        string Description { get; }

        string[] ConfigItems { get; }

        T CreateInstance(IReadOnlyDictionary<string, string> configOptions);
    }
}
