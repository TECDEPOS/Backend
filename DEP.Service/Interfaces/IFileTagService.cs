using DEP.Repository.Models;

namespace DEP.Service.Interfaces
{
    public interface IFileTagService
    {
        Task<bool> AddFileTag(FileTag filetag);
        Task<FileTag> UpdateFileTag(FileTag filetag);
        Task<FileTag> DeleteFileTag(int id);
        Task<List<FileTag>> GetFileTags();
        Task<FileTag> GetFileTagById(int id);
        Task<FileTag> GetFileTagByName(string name);
    }
}
