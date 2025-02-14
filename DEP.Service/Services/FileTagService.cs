using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Repository.ViewModels;
using DEP.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEP.Service.Services
{
    public class FileTagService : IFileTagService
    {
        private readonly IFileTagRepository repo;

        public FileTagService(IFileTagRepository repo) { this.repo = repo; }

        public Task<bool> AddFileTag(FileTagViewModel filetagViewModel)
        {
            var fileTag = new FileTag
            {
                TagName = filetagViewModel.TagName,
                FileTagUserRoles = filetagViewModel.FileTagUserRoles.Select(r => new FileTagUserRole
                {
                    FileTagId = r.FileTagId, // Only set the ID
                    Role = r.Role
                }).ToList()
            };

            return repo.AddFileTag(fileTag);
        }

        public async Task<bool> DeleteFileTag(int id)
        {
            return await repo.DeleteFileTagById(id);
        }

        public async Task<FileTag> GetFileTagById(int id)
        {
            return await repo.GetFileTagByID(id);
        }

        public async Task<FileTag> GetFileTagByName(string name)
        {
            return await repo.GetFileTagByname(name);
        }

        public async Task<List<FileTagViewModel>> GetFileTags()
        {
            // Get the list of FileTag entities from the repository
            List<FileTag> fileTags = await repo.GetAllFileTag();

            // Map each FileTag entity to a FileTagViewModel
            List<FileTagViewModel> viewModels = fileTags.Select(ft => new FileTagViewModel
            {
                
                FileTagId = ft.FileTagId,
                TagName = ft.TagName,
                FileTagUserRoles = ft.FileTagUserRoles.Select(utr => new FileTagUserRoleViewModel
                {
                    FileTagId = utr.FileTagId,
                    Role = utr.Role
                }).ToList()
            }).ToList();

            return viewModels;
        }

        public async Task<bool> UpdateFileTag(FileTagViewModel filetagViewModel)
        {
            var fileTagEntity = new FileTag
            {
                FileTagId = filetagViewModel.FileTagId,
                TagName = filetagViewModel.TagName,
                FileTagUserRoles = filetagViewModel.FileTagUserRoles
                    .Select(vm => new FileTagUserRole
                    {
                        FileTagId = vm.FileTagId,
                        Role = vm.Role
                    }).ToList()
            };

            return await repo.UpdateFileTag(fileTagEntity);
        }


        //public async Task<bool> UpdateFileTag(FileTagViewModel filetagViewModel)
        //{
        //    // Fetch the existing FileTag from the database
        //    var existingFileTag = await repo.GetFileTagByID(filetagViewModel.FileTagId);

        //    if (existingFileTag == null)
        //    {
        //        return false; // Or throw an exception if preferred
        //    }

        //    // Update properties
        //    existingFileTag.TagName = filetagViewModel.TagName;

        //    // Sync the user roles (Add new ones, remove missing ones)
        //    var existingRoles = existingFileTag.FileTagUserRoles;
        //    var newRoles = filetagViewModel.FileTagUserRoles.Select(vm => vm.Role).ToList();

        //    // Add new roles
        //    foreach (var role in newRoles.Except(existingRoles.Select(utr => utr.Role)))
        //    {
        //        existingFileTag.FileTagUserRoles.Add(new FileTagUserRole { FileTagId = existingFileTag.FileTagId, Role = role });
        //    }

        //    // Remove roles that no longer exist in the new list
        //    existingFileTag.FileTagUserRoles.RemoveAll(utr => !newRoles.Contains(utr.Role));

        //    return await repo.UpdateFileTag(existingFileTag);
        //}



    }
}
