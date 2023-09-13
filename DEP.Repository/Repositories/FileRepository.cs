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

            string time = Regex.Replace(DateTime.Now.ToString(), "[/.:-]", " ");
            var fileName = time + myFile.FileName;
            var path = Path.Combine(configuration.GetSection("Appsettings:AppDirectory").Value, fileName);

            NetworkCredential credential = new NetworkCredential(
                configuration.GetSection("Appsettings:Username").Value,
                configuration.GetSection("Appsettings:Password").Value);

            file.FileName = myFile.FileName;
            file.FilePath = path;
            file.FileFormat = Path.GetExtension(myFile.FileName);
            file.ContentType = myFile.ContentType;

            using (new NetworkConnection(configuration.GetSection("Appsettings:AppDirectory").Value, credential))
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await myFile.CopyToAsync(stream);
                }
            }
            return file;
        }

        public async Task<List<File>> GetFiles()
        {
            var files = await context.Files.
                Select(x => new
                {
                    FileId = x.FileId,
                    FileName = x.FileName,
                    FileUrl = x.FilePath,
                    UploadDate = x.UploadDate,
                    ContentType = x.ContentType,
                    FileFormat = x.FileFormat,
                    FileTag =
                    new
                    {
                        FileTagId = x.FileTag.FileTagId,
                        TagName = x.FileTag.TagName,
                    },
                    Person = new
                    {
                        PersonId = x.Person.PersonId,
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
                    FilePath = x.FileUrl,
                    UploadDate = x.UploadDate,
                    ContentType = x.ContentType,
                    FileFormat = x.FileFormat,
                    FileTag = new FileTag()
                    {
                        FileTagId = x.FileTag.FileTagId,
                        TagName = x.FileTag.TagName,
                    },
                    Person = new Person()
                    {
                        PersonId = x.Person.PersonId,
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
            //context.Files.Add(file);
            context.Files.Add(file);
            var tt = new File();
            try
            {
                await context.SaveChangesAsync();
                tt = await context.Files.Include(x => x.FileTag).FirstOrDefaultAsync(x => x.FileId == file.FileId);
            }
            catch (Exception ex)
            {
                // Log or print the exception details for debugging
                Console.WriteLine(ex.ToString());
                throw; // Rethrow the exception to handle it at a higher level
            }
            return tt;
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

            if (file is null)
            {
                return null;
            }

            NetworkCredential credential = new NetworkCredential(
                configuration.GetSection("Appsettings:Username").Value,
                configuration.GetSection("Appsettings:Password").Value);

            using (new NetworkConnection(configuration.GetSection("Appsettings:AppDirectory").Value, credential))
            {
                if (System.IO.File.Exists(file.FilePath))
                {
                    System.IO.File.Delete(file.FilePath);
                }
            }
            context.Files.Remove(file);
            await context.SaveChangesAsync();
            return file;
        }
    }
}
