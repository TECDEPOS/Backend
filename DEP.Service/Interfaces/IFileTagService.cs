using DEP.Repository.Models;

namespace DEP.Service.Interfaces
{
    public interface IFileTagService
    {
        public Task<FileTag> AddFileTag(FileTag filetag);
        public Task<FileTag> UpdateFileTag(FileTag filetag);
        public Task<FileTag> DeleteFileTag(int id);
        public Task<List<FileTag>> GetFileTags();
        public Task<FileTag> GetFileTagById(int id);
        public Task<FileTag> GetFileTagByName(string name);
    }
}
