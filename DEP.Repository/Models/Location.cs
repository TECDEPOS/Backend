namespace DEP.Repository.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<User> Users { get; set; } = new List<User>();
        public List<Person> Persons { get; set; } = new List<Person>();
    }
}
