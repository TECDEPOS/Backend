namespace DEP.Repository.Models
{
    public class FileTag
    {
        public int FileTagId { get; set; }
        public string TagName { get; set; } = string.Empty;
        public bool DKVisability { get; set; }
        public bool HRVisability { get; set; }
        public bool PKVisability { get; set; }
        //public List<File> Files { get; set; } = new List<File>();
    }
}
