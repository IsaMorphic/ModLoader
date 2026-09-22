using ModLoader.Core.Plugins.Interfaces;
using System.Collections.Generic;

namespace ModLoader.Core.Abstract
{
    public interface IPluginSource
    {
        IReadOnlyDictionary<string, IPlugin<T>> GetPluginsOfInterface<T>();
    }
}