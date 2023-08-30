using DEP.Repository.Models;
using DEP.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Infrastructure;
using File = DEP.Repository.Models.File;

namespace DEP.Service.Interfaces
{
    public interface IFileService
    {
        Task<File> AddFile(IFormFile file, int userId, int tagId);
        Task<File> UpdateFile(File file);
        Task<File> DeleteFile(int id);
        Task<List<File>> GetFile();
        Task<File> GetFileById(int id);
        Task<List<File>> GetFileByName(string name);
    }
}
