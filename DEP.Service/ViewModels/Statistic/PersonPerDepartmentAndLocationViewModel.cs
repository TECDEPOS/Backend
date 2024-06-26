namespace DEP.Service.ViewModels.Statistic
{
    public class PersonPerDepartmentAndLocationViewModel
    {
        public List<PersonPerDepartmentViewModel> Departments { get; set; } = new List<PersonPerDepartmentViewModel>();
        public List<PersonPerLocationViewModel> Locations { get; set; } = new List<PersonPerLocationViewModel>();
    }
}
