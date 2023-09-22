namespace DEP.Repository.Models
{
    public class FileTag
    {
        public int FileTagId { get; set; }
        public string TagName { get; set; } = string.Empty;
        public bool DKVisablity { get; set; }
        public bool HRVisablity { get; set; }
        public bool PKVisablity { get; set; }
        //public List<File> Files { get; set; } = new List<File>();
    }
}
