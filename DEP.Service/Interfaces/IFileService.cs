using DEP.Repository.Models;
using DEP.Service.ViewModels;
using Microsoft.EntityFrameworkCore.Infrastructure;
using File = DEP.Repository.Models.File;

namespace DEP.Service.Interfaces
{
    public interface IFileService
    {
        Task<File> AddFile(AddFileViewModel file);
        Task<File> UpdateFile(AddFileViewModel file);
        Task<File> DeleteFile(int id);
        Task<List<File>> GetFile();
        Task<File> GetFileById(int id);
        Task<File> GetFileByName(string name);
    }
}
