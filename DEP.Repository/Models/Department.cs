using System.Text.Json.Serialization;

namespace DEP.Repository.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;


        // JsonIgnore to prevent circular references resulting in an exception.
        [JsonIgnore]
        public List<User> Users { get; set; } = new List<User>();
        [JsonIgnore]
        public List<Person> Persons { get; set; } = new List<Person>();
    }
}
