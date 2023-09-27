namespace DEP.Repository.Models
{
    public class PersonModule
    {
        public int PersonModuleId { get; set; }
        public int PersonId { get; set; }
        public int ModuleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public ModuleType ModuleType { get; set; }


        public virtual Module? Module { get; set; }
        public virtual Person? Person { get; set; }
    }
}
