using DEP.Repository.Models;

namespace DEP.Repository.ViewModels
{
    public class UserDashboardViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int? LocationId { get; set; }
        public string? LocationName { get; set; }
        public int? EducationBossId { get; set; }
        public string? EducationBossName { get; set; }
        public UserRole UserRole { get; set; }
        public DateTime PasswordExpiryDate { get; set; }
        public List<UserViewModel> EducationLeaders { get; set; } = new List<UserViewModel>();
        public List<PersonViewModel> EducationalConsultantPersons { get; set; } = new List<PersonViewModel>();
        public List<PersonViewModel> EducationLeaderPersons { get; set; } = new List<PersonViewModel>();
        public List<PersonViewModel> OperationCoordinatorPersons { get; set; } = new List<PersonViewModel>();
    }
}
