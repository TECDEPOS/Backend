namespace DEP.Repository.Models
{
    public class Files
    {
        public int FileId { get; set; }
        public string FileUrl { get; set; }
        public int TagId { get; set; }
        public int PersonId { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
