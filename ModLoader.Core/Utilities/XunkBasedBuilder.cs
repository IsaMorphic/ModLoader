namespace ModLoader.Core.Utilities
{
    public interface IXunkBasedBuilder
    {
        string Name { get; }

        string DefaultExt { get; }

        Task BuildAsync(string originalFilePath, string moddedFilePath, string outputFilePath);
    }
}
