using DEP.Repository.Context;
using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.IO;
using File = DEP.Repository.Models.File;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace DEP.Repository.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly DatabaseContext context;
        private readonly IConfiguration configuration;

        public FileRepository(DatabaseContext context, IConfiguration configuration) { this.context = context; this.configuration = configuration; }


        public async Task<File> UploadFile(IFormFile myFile)
        {
            File file = new File();

            string time = Regex.Replace(DateTime.Now.ToString(), "[/.:-]", " ") + (".");
            List<string> name = myFile.FileName.Split('.').ToList();
            name.Insert(1, time);
            var fileName = string.Join("", name);
            var path = Path.Combine(configuration.GetSection("Appsettings:AppDirectory").Value, fileName);

            NetworkCredential credential = new NetworkCredential(
                configuration.GetSection("Appsettings:Username").Value,
                configuration.GetSection("Appsettings:Password").Value);

            file.FileName = myFile.FileName;
            file.FileUrl = path;

            DirectoryInfo dir = new DirectoryInfo(path);


            using (new NetworkConnection(configuration.GetSection("Appsettings:AppDirectory").Value, credential))
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await myFile.CopyToAsync(stream);
                }
            }
            return file;
        }

        public async Task<File> CreateFileInDB(File file)
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

            System.IO.File.Delete(file.FileUrl);
            context.Files.Remove(file);
            await context.SaveChangesAsync();
            return file;
        }
    }
}
