﻿
using DEP.Repository.Models;
using Microsoft.AspNetCore.Http;

namespace DEP.Repository.Interfaces
{
    public interface IFileRepository
    {
        Task<Models.File> UploadFile(IFormFile myFile);
        Task<List<Models.File>> UploadMultipleFiles(List<IFormFile> files, List<FileTag> fileTags, int personId);
        Task<Models.File> AddFile(Models.File file);
        Task<Models.File> UpdateFile(Models.File file);
        Task<Models.File> DeleteFile(int id);
        Task<List<Models.File>> GetFiles(int roleId);
        Task<Models.File> GetFileById(int id);
        Task<List<Models.File>> GetFileByName(string name);
    }
}
