namespace DEP.Repository.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<User> Users { get; set; } = new List<User>();
        public List<Person> Persons { get; set; } = new List<Person>();
    }
}
