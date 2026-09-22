using ModLoader.Core.Abstract;
using ModLoader.Core.Exceptions;
using ModLoader.Core.Plugins.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core.Concrete
{
    public class AggregatePluginSource : IPluginSource
    {
        public HashSet<IPluginSource> Sources { get; }

        public AggregatePluginSource() 
        {
            Sources = new();
        }

        public IReadOnlyDictionary<string, IPlugin<T>> GetPluginsOfInterface<T>()
        {
            try
            {
                return Sources
                    .SelectMany(source => source.GetPluginsOfInterface<T>())
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }
            catch (ArgumentException ex) 
            {
                throw new ConflictException<IPlugin<T>>("Plugin of same name has mulitple sources.", ex);
            }
        }
    }
}
