using DEP.Repository.Context;
using DEP.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace DEP.Repository.Repositories
{
    public class FileTagRepository
    {
        private readonly DatabaseContext context;

        public FileTagRepository(DatabaseContext context) { this.context = context; }

        public async Task<FileTag> AddFileTag(FileTag fileTag)
        {
            await context.SaveChangesAsync();
            return fileTag;
        }

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
            var filetag = await context.FileTags.FirstOrDefaultAsync(x => x.TagName == name);
            return filetag;
            
        }

        public async Task<FileTag> DeleteFileTagById(int id)
        {
            var filetag = await context.FileTags.FindAsync(id);
            context.FileTags.Remove(filetag);
            await context.SaveChangesAsync();
            return filetag;
        }

        public async Task<FileTag> UpdateFileTag( FileTag fileTag)
        {
            context.Entry(fileTag).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return fileTag;
        }
    }
}
