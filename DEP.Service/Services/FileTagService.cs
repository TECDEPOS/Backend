using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEP.Service.Services
{
    public class FileTagService : IFileTagService
    {
        private readonly IFileTagRepository repo;

        public FileTagService(IFileTagRepository repo) { this.repo = repo; }

        public Task<bool>? AddFileTag(FileTag filetag)
        {
            return repo.AddFileTag(filetag);
        }

        public async Task<bool> DeleteFileTag(int id)
        {
            return await repo.DeleteFileTagById(id);
        }

        public async Task<FileTag> GetFileTagById(int id)
        {
            return await repo.GetFileTagByID(id);
        }

        public async Task<FileTag> GetFileTagByName(string name)
        {
            return await repo.GetFileTagByname(name);
        }

        public async Task<List<FileTag>> GetFileTags()
        {
            return await repo.GetAllFileTag();
        }

        public async Task<bool> UpdateFileTag(FileTag filetag)
        {
            return await repo.UpdateFileTag(filetag);
        }
    }
}
