using DEP.Repository.Interfaces;
using DEP.Service.Interfaces;
using DEP.Service.ViewModels;
using File = DEP.Repository.Models.File;

namespace DEP.Service.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository repo;
        public FileService(IFileRepository repo) { this.repo = repo; }
        public async Task<File> AddFile(File file)
        {
            return await repo.AddFile(file);
        }

        public async Task<File> DeleteFile(int id)
        {
            return await repo.DeleteFile(id);
        }

        public async Task<List<File>> GetFile()
        {
            return await repo.GetFiles();
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
            newFile.FileUrl = file.FileUrl;
            newFile.UploadDate = file.UploadDate;

            return newFile;
        }
    }
}
