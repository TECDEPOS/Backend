using DEP.Repository.Context;
using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using File = DEP.Repository.Models.File;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System;

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

        public async Task<List<File>> UploadMultipleFiles(List<IFormFile> files, List<FileTag> fileTags, int personId)
        {
            // Create list for returning once files are uploaded
            List<File> filesToReturn = new List<File>();


            // path and time variables declared outside of for-loop, values will be changed in every iteration of the loop.
            var time = string.Empty;
            var path = string.Empty;
            var path1 = string.Empty;
            var fileName = string.Empty;

            // Resolve the AppDirectory from environment variables
            var appDirectory = Environment.ExpandEnvironmentVariables(configuration["AppSettings:AppDirectory"]);

            // Ensure the directory exists
            if (!Directory.Exists(appDirectory))
            {
                Directory.CreateDirectory(appDirectory);
            }

            for (int i = 0; i < files.Count; i++)
            {
                // Set time format and path for file
                time = Regex.Replace(DateTime.Now.ToString(), "[/.:-]", " ");
                fileName = i + " " + time + files[i].FileName;
                path = Path.Combine(appDirectory, fileName);

                // Create File object, set values and add it to the list of files to return
                File tempFile = new File();
                tempFile.FileName = files[i].FileName;
                tempFile.FilePath = path;
                tempFile.FileFormat = Path.GetExtension(files[i].FileName);
                tempFile.ContentType = files[i].ContentType;
                tempFile.PersonId = personId;


                // FileTagId explodes if it's null due to the property not being nullable in the DB and on the model
                if (fileTags![i] is not null)
                {
                    tempFile.FileTagId = fileTags![i].FileTagId;
                }
                tempFile.UploadDate = DateTime.Now;


                // Upload file to server directory
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await files[i].CopyToAsync(stream);
                }
                // Add to DB and add it to the returnList
                var newFile = await AddFile(tempFile);
                filesToReturn.Add(newFile);
            }

            return filesToReturn;
        }

        public async Task<List<File>> GetFiles(int roleId)
        {
            var files = await context.Files.Include(x => x.FileTag).ThenInclude(ft => ft.FileTagUserRoles).Include(x => x.Person).ToListAsync();

            return files;
        }

        public async Task<File> GetFileById(int id)
        {
            var file = await context.Files.Include(x => x.FileTag).ThenInclude(ft => ft.FileTagUserRoles).Include(x => x.Person).FirstOrDefaultAsync(x => x.FileId == id);
            return file;
        }

        public async Task<List<File>> GetFileByName(string name)
        {
            var file = await context.Files.Include(x => x.FileTag).ThenInclude(ft => ft.FileTagUserRoles).Include(x => x.Person).Where(x => x.FileName.Contains(name.ToLower())).ToListAsync();
            return file;
        }

        public async Task<File> AddFile(File file)
        {
            context.Files.Add(file);
            var tt = new File();
            try
            {
                await context.SaveChangesAsync();
                // Getting the full file from DB so FileTag object is included
                tt = await context.Files.Include(x => x.FileTag).ThenInclude(ft => ft.FileTagUserRoles).FirstOrDefaultAsync(x => x.FileId == file.FileId);
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

            if (System.IO.File.Exists(file.FilePath))
            {
                System.IO.File.Delete(file.FilePath);
            }
            context.Files.Remove(file);
            await context.SaveChangesAsync();
            return file;
        }
    }
}
