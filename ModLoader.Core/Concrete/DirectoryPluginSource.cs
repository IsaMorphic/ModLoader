using System.Collections.Generic;

namespace ModLoader.Core.Concrete
{
    using Abstract;
    using Plugins.Interfaces;
    using System.IO;
    using System.Linq;

    public class DirectoryPluginSource : IPluginSource
    {
        private readonly string _directoryPath;

        private readonly AssemblyPluginSource[] _pluginSources;

        public DirectoryPluginSource(string directoryPath) 
        {
            _directoryPath = directoryPath;
            _pluginSources = Directory
                .EnumerateFiles(_directoryPath, "*.dll", SearchOption.AllDirectories)
                .Select(asmPath => new AssemblyPluginSource(asmPath))
                .ToArray();
        }

        public IReadOnlyDictionary<string, IPlugin<T>> GetPluginsOfInterface<T>()
        {
            return _pluginSources.SelectMany(pluginSource => pluginSource.GetPluginsOfInterface<T>().Values).ToDictionary(plugin => plugin.Name);
        }
    }
}
