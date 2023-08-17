using DEP.Repository.Models;

namespace DEP.Service.ViewModels
{
    public class AddFileViewModel
    {
        public int FileId { get; set; }
        public string FileName { get; set; } = string.Empty;
        //public int FileTagId { get; set; }
        public string FileUrl { get; set; } = string.Empty;
        public DateTime UploadDate { get; set; }
    }
}
