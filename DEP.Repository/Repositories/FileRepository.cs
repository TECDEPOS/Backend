using DEP.Repository.Context;
using DEP.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace DEP.Repository.Repositories
{
    public class FileRepository
    {
        private readonly DatabaseContext context;
        

        public FileRepository(DatabaseContext context) { this.context = context; }

        public async Task<Models.File> CreateFile(Models.File file)
        {
            await context.SaveChangesAsync();
            return file;
        }

        public async Task<List<Models.File>> GetAllFiles()
        {
            var files = await context.Files.ToListAsync();
            return files;
        }

        public async Task<Models.File> GetFileById(int id)
        {
            var file = await context.Files.FindAsync(id);
            return file;
        }

        public async Task<Models.File> GetFileByName(string name)
        {
            var file = await context.Files.FirstOrDefaultAsync(x => x.FileName == name);
            return file;
        }


    }
}
