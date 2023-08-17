using DEP.Repository.Context;
using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using Microsoft.EntityFrameworkCore;
using File = DEP.Repository.Models.File;

namespace DEP.Repository.Repositories
{
    public class FileRepository: IFileRepository
    {
        private readonly DatabaseContext context;
        

        public FileRepository(DatabaseContext context) { this.context = context; }

        public async Task<Models.File> CreateFile(Models.File file)
        {
                context.Files.Add(file);
                await context.SaveChangesAsync();
                return file;
        }

        public async Task<List<Models.File>> GetFiles()
        {
            var files = await context.Files.
                Select(x => new
                {
                    FileId = x.FileId,
                    FileName = x.FileName,
                    FileUrl = x.FileUrl,
                    UploadDate = x.UploadDate,
                    FileTag =
                    new
                    {
                        FileTagId = x.FileTag.FileTagId,
                        TagName = x.FileTag.TagName,
                    },
                    Person = new
                    {
                        Name = x.Person.Name

                    }
                }).ToListAsync();

            var dummyfiles = new List<File>();
            foreach (var x in files)
            {
                dummyfiles.Add(new File()
                {
                    FileId = x.FileId,
                    FileName = x.FileName,
                    FileUrl = x.FileUrl,
                    UploadDate = x.UploadDate,
                    FileTag = new FileTag()
                    {
                        FileTagId = x.FileTag.FileTagId,
                        TagName = x.FileTag.TagName,
                    },
                    Person = new Person()
                    {
                        Name = x.Person.Name
                    }
                });
            }
            return dummyfiles;
        }

        public async Task<Models.File> GetFileById(int id)
        {
            var file = await context.Files.Include(x => x.FileTag).Include(x => x.Person).FirstOrDefaultAsync(x => x.FileId == id);
            return file;
        }

        public async Task<Models.File> GetFileByName(string name)
        {
            var file = await context.Files.Include(x => x.FileTag).Include(x => x.Person).FirstOrDefaultAsync(x => x.FileName == name);
            return file;
        }

        public async Task<Models.File> AddFile(Models.File file)
        {
                context.Files.Add(file);
                await context.SaveChangesAsync();
                return file;
        }

        public async Task<Models.File> UpdateFile(Models.File file)
        {
            context.Entry(file).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return file;
        }

        public async Task<Models.File> DeleteFile(int id)
        {
            var file = await context.Files.FindAsync(id);
            context.Files.Remove(file);
            await context.SaveChangesAsync();
            return file;
        }
    }
}
