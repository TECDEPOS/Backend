namespace DEP.Repository.Models
{
    public class PersonModule
    {
        public int PersonId { get; set; }
        public int ModuleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public ModuleType ModuleType { get; set; }


        public Module Module { get; set; }
        public Person Person { get; set; }
    }
}
