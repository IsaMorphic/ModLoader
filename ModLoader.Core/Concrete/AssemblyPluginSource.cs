using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ModLoader.Core.Concrete
{
    using Abstract;
    using Plugins.Interfaces;

    public class AssemblyPluginSource : IPluginSource
    {
        private readonly Assembly _assembly;

        public AssemblyPluginSource(string assemblyPath)
        {
            _assembly = Assembly.LoadFrom(assemblyPath);
        }

        public AssemblyPluginSource(Assembly assembly)
        {
            _assembly = assembly;
        }

        public IReadOnlyDictionary<string, IPlugin<T>> GetPluginsOfInterface<T>()
        {
            var pluggableTypes = _assembly.DefinedTypes.Where(t => t.ImplementedInterfaces.Contains(typeof(IPlugin<T>)));
            return pluggableTypes
                .Select(type => Activator.CreateInstance(type) as IPlugin<T>)
                .ToDictionary(plugin => plugin.Name);
        }
    }
}
