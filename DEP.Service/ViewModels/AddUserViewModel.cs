using DEP.Repository.Models;

namespace DEP.Service.ViewModels
{
    public class AddUserViewModel
    {
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int? EducationBossId { get; set; }
        public int? LocationId { get; set; }
        public int? DepartmentId { get; set; }
        public UserRole UserRole { get; set; }
    }
}
