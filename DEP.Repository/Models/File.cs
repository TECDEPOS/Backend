namespace DEP.Repository.Models
{
    public class File
    {
        public int FileId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string FileFormat { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public int? FileTagId { get; set; }
        public int PersonId { get; set; }
        public DateTime UploadDate { get; set; }
        public FileTag? FileTag { get; set; }
        public Person? Person { get; set; }
    }
}
