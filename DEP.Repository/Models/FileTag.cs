namespace DEP.Repository.Models
{
    public class FileTag
    {
        public int FileTagId { get; set; }
        public string TagName { get; set; } = string.Empty;

        public List<FileTagUserRole> FileTagUserRoles { get; set; } = new List<FileTagUserRole>();

    }
}
