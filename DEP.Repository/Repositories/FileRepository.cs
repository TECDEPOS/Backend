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

        public async Task<File> CreateFile(File file)
        {
                context.Files.Add(file);
                await context.SaveChangesAsync();
                return file;
        }

        public async Task<List<File>> GetFiles()
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

        public async Task<File> GetFileById(int id)
        {
            var file = await context.Files.Include(x => x.FileTag).Include(x => x.Person).FirstOrDefaultAsync(x => x.FileId == id);
            return file;
        }

        public async Task<List<File>> GetFileByName(string name)
        {
            var file = await context.Files.Include(x => x.FileTag).Include(x => x.Person).Where(x => x.FileName.Contains(name.ToLower())).ToListAsync();
            return file;
        }

        public async Task<File> AddFile(File file)
        {
                context.Files.Add(file);
                await context.SaveChangesAsync();
                return file;
        }

        public async Task<File> UpdateFile(File file)
        {
            context.Entry(file).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return file;
        }

        public async Task<File> DeleteFile(int id)
        {
            var file = await context.Files.FindAsync(id);
            context.Files.Remove(file);
            await context.SaveChangesAsync();
            return file;
        }
    }
}
