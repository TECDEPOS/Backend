using DEP.Repository.Models;

namespace DEP.Repository.ViewModels
{
    public class FileTagViewModel
    {
        public int FileTagId { get; set; }
        public string TagName { get; set; } = string.Empty;
        public List<FileTagUserRoleViewModel> FileTagUserRoles { get; set; } = new();
    }

    public class FileTagUserRoleViewModel
    {
        public int FileTagId { get; set; }
        public UserRole Role { get; set; }
    }
}
