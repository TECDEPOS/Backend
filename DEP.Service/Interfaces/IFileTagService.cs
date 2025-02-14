using DEP.Repository.Models;
using DEP.Repository.ViewModels;

namespace DEP.Service.Interfaces
{
    public interface IFileTagService
    {
        Task<bool> AddFileTag(FileTagViewModel filetag);
        Task<bool> UpdateFileTag(FileTagViewModel filetag);
        Task<bool> DeleteFileTag(int id);
        Task<List<FileTagViewModel>> GetFileTags();
        Task<FileTag> GetFileTagById(int id);
        Task<FileTag> GetFileTagByName(string name);
    }
}
