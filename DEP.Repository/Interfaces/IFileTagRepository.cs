using DEP.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEP.Repository.Interfaces
{
    public interface IFileTagRepository
    {
        Task<bool> AddFileTag(FileTag fileTag);

        Task<List<FileTag>> GetAllFileTag();

        Task<FileTag> GetFileTagByID(int id);

        Task<FileTag> GetFileTagByname(string name);

        Task<FileTag> DeleteFileTagById(int id);

        Task<FileTag> UpdateFileTag(FileTag fileTag);
    }
}
