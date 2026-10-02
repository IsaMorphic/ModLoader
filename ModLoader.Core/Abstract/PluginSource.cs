namespace ModLoader.Core.Abstract
{
    using Plugins.Interfaces;

    public interface IPluginSource
    {
        IReadOnlyDictionary<string, IPlugin<T>> GetPluginsOfInterface<T>();
    }
}