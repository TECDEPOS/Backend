using DEP.Repository.Context;
using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace DEP.Repository.Repositories
{
    public class FileTagRepository : IFileTagRepository
    {
        private readonly DatabaseContext context;

        public FileTagRepository(DatabaseContext context) { this.context = context; }

        public async Task<List<FileTag>> GetAllFileTag()
        {
            var filetags = await context.FileTags.ToListAsync();
            return filetags;
        }       

        public async Task<FileTag> GetFileTagByID(int id)
        {
            var filetag = await context.FileTags.FindAsync(id);
            return filetag;
        }

        public async Task<FileTag> GetFileTagByname(string name)
        {
            var filetag = await context.FileTags.FirstOrDefaultAsync(x => x.TagName.Contains(name.ToLower()));
            return filetag;
        }

        public async Task<bool> AddFileTag(FileTag fileTag)
        {
            context.FileTags.Add(fileTag);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateFileTag(FileTag fileTag)
        {
            context.Entry(fileTag).State = EntityState.Modified;
            var result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteFileTagById(int id)
        {
            var fileTag = await context.FileTags.FindAsync(id);

            if (fileTag is null)
            {
                return false;
            }

            context.FileTags.Remove(fileTag);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }


    }
}
