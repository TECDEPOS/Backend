namespace DEP.Service.ViewModels
{
    public class PersonPerDepartmentViewModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public int TeacherCount { get; set; }
    }
}
