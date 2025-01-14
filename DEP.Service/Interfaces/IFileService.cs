using DEP.Repository.Models;
using Microsoft.AspNetCore.Http;
using File = DEP.Repository.Models.File;

namespace DEP.Service.Interfaces
{
    public interface IFileService
    {
        Task<File> AddFile(IFormFile file, int userId, int tagId);
        //Task<List<File>> AddMultipleFiles(IFormCollection formData);
        Task<List<File>> AddMultipleFiles(List<IFormFile> files, List<FileTag> fileTags, int personId);
        Task<File> UpdateFile(File file);
        Task<File> DeleteFile(int id);
        Task<List<File>> GetFiles(int roleId);
        Task<File> GetFileById(int id);
        Task<List<File>> GetFileByName(string name);
    }
}
