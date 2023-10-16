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

        public async Task<List<File>> UploadMultipleFiles(IFormCollection formData)
        {
            // Create list for returning once files are uploaded
            List<File> filesToReturn = new List<File>();

            // Sets the Network Credentials to authenticate to the server
            NetworkCredential credential = new NetworkCredential(
                configuration.GetSection("Appsettings:Username").Value,
                configuration.GetSection("Appsettings:Password").Value);


            var files = formData.Files;
            // Get the FileTags as stringified and Deserialize them into a list of FileTag objects.
            var fileTags = formData["fileTags"];
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var fileTagList = JsonSerializer.Deserialize<List<FileTag>>(fileTags!, options);


            // path and time variables declared outside of for-loop, values will be changed in every iteration of the loop.
            var time = string.Empty;
            var path = string.Empty;
            var fileName = string.Empty;

            for (int i = 0; i < formData.Files.Count; i++)
            {
                // Set time format and path for file
                time = Regex.Replace(DateTime.Now.ToString(), "[/.:-]", " ");
                fileName = i + " " + time + files[i].FileName;
                path = Path.Combine(configuration.GetSection("Appsettings:AppDirectory").Value, fileName);

                // Create File object, set values and add it to the list of files to return
                File tempFile = new File();
                tempFile.FileName = files[i].FileName;
                tempFile.FilePath = path;
                tempFile.FileFormat = Path.GetExtension(files[i].FileName);
                tempFile.ContentType = files[i].ContentType;
                tempFile.PersonId = Convert.ToInt32(formData["personId"][0]);


                // FileTagId explodes if it's null due to the property not being nullable in the DB and on the model
                if (fileTagList![i] is not null)
                {
                    tempFile.FileTagId = fileTagList![i].FileTagId;
                }
                tempFile.UploadDate = DateTime.Now;


                // Use NetworkConnection to gain access to server directory
                using (new NetworkConnection(configuration.GetSection("Appsettings:AppDirectory").Value, credential))
                {
                    // Upload file to server directory
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await files[i].CopyToAsync(stream);
                    }
                }
                // Add to DB and add it to the returnList
                var newFile = await AddFile(tempFile);
                filesToReturn.Add(newFile);
            }

            return filesToReturn;
        }

        public async Task<List<File>> GetFiles(int roleId)
        {
            var files = await context.Files.Include(x => x.FileTag).Include(x => x.Person).ToListAsync();

            if (roleId == 1 || roleId == 4)
            {
                files = files.Where(x => x.FileTag?.PKVisability == true).ToList();
            }
            else if (roleId == 2 || roleId == 5)
            {
                files = files.Where(x => x.FileTag?.HRVisability == true).ToList();
            }
            else if (roleId == 3 || roleId == 6)
            {
                files = files.Where(x => x.FileTag?.DKVisability == true).ToList();
            }
            else if (roleId == 0)
            {
                files.Clear();
            }

            return files;
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
            var tt = new File();
            try
            {
                await context.SaveChangesAsync();
                // Getting the full file from DB so FileTag object is included
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
