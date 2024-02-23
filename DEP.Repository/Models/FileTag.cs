namespace DEP.Repository.Models
{
    public class FileTag
    {
        public int FileTagId { get; set; }
        public string TagName { get; set; } = string.Empty;
        public bool DKVisibility { get; set; }
        public bool HRVisibility { get; set; }
        public bool PKVisibility { get; set; }
        public bool EducationLeaderVisibility { get; set; }
        public bool EducationBossVisibility { get; set; }
        public bool ControllerVisibility { get; set; }
    }
}
