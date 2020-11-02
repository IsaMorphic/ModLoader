using System.Threading.Tasks;

namespace ModLoader.Core.Abstract
{
    public interface IFileSystem
    {
        Task MountAsync();

        Task<StagedFile> StageFileAsync(string path, bool createNew = false);
        Task UnstageFileAsync(StagedFile file); 

        Task CommitFileAsync(StagedFile file);
        Task RemoveFileAsync(string path);

        Task UnmountAsync();
    }
}
