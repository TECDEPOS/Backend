using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Service.Interfaces;
using DEP.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using File = DEP.Repository.Models.File;

namespace DEP.Service.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository repo;
        public FileService(IFileRepository repo) { this.repo = repo; }
        public async Task<File> AddFile(IFormFile file, int personId, int tagId)
        {
            File newfile = await repo.UploadFile(file);
            newfile.PersonId = personId;
            newfile.FileTagId = tagId;
            newfile.UploadDate = DateTime.Now;

            return await repo.AddFile(newfile);
        }

        public async Task<List<File>> AddMultipleFiles(List<IFormFile> files, List<FileTag> fileTags, int personId)
        {
            var fileList = await repo.UploadMultipleFiles(files, fileTags, personId);
            return fileList;
        }

        public async Task<File> DeleteFile(int id)
        {
            return await repo.DeleteFile(id);
        }

        public async Task<List<File>> GetFiles(int roleId)
        {
            return await repo.GetFiles(roleId);
        }

        public async Task<File> GetFileById(int id)
        {
            return await repo.GetFileById(id);
        }

        public async Task<List<File>> GetFileByName(string name)
        {
            return await repo.GetFileByName(name);
        }


        //Could be used? Dont see why :) 
        //Haven't tested for bug, or if it even works
        public async Task<File> UpdateFile(File file)
        {
            return await repo.UpdateFile(file);
        }

        private File ViewModelconverter(AddFileViewModel file)
        {
            File newFile = new File();
            newFile.FileId = file.FileId;
            newFile.FileName = file.FileName;
            //newFile.FileTagId = file.FileTagId;
            newFile.FilePath = file.FileUrl;
            newFile.UploadDate = file.UploadDate;

            return newFile;
        }
    }
}
