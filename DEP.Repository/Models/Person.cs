namespace DEP.Repository.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; } = string.Empty;
        //Ayo what the fuck check this out later. -Sebastian
        //public int DepartmentId { get; set; }
        //public int LocationId { get; set; }
        //public int EducationalConsultantId { get; set; }
        //public int OperationCoordinatorId { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool SvuEligible { get; set; }

        public User? EducationalConsultant { get; set; }
        public User? OperationCoordinator { get; set; }
        public Department? Department { get; set; }
        public Location? Location { get; set; }
        public List<File> Files { get; set; } = new List<File>();
        public List<PersonModule> PersonModules { get; set; } = new List<PersonModule>();
    }
}
