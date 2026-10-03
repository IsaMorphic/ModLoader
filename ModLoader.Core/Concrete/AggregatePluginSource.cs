namespace ModLoader.Core.Concrete
{
    using Abstract;
    using Exceptions;
    using Plugins.Interfaces;

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
                    .ToDictionary();
            }
            catch (ArgumentException ex) 
            {
                throw new ConflictException<IPlugin<T>>("Plugin of same name has mulitple sources.", ex);
            }
        }
    }
}
