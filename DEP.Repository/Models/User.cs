using System.Text.Json.Serialization;

namespace DEP.Repository.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int? LocationId { get; set; }
        public int? DepartmentId { get; set; }
        public int? EducationBossId { get; set; } //Uddannelseschef
        public string UserName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Byte[] PasswordHash { get; set; } = new byte[32];
        public Byte[] PasswordSalt { get; set; } = new byte[32];
        public UserRole UserRole { get; set; }

        public DateTime PasswordExpiryDate { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryDate { get; set; }


        public Location? Location { get; set; }
        public Department? Department { get; set; }
        public User? EducationBoss { get; set; } //Uddannelseschef
        public List<User> EducationLeaders { get; set; } = new List<User>();// Uddannelsesledere


        // JsonIgnore to prevent circular references resulting in an exception.
        [JsonIgnore]
        public List<Person> EducationalConsultantPersons { get; set; } = new List<Person>();
        [JsonIgnore]
        public List<Person> OperationLeaderPersons { get; set; } = new List<Person>();
        [JsonIgnore]
        public List<Person> OperationCoordinatorPersons { get; set; } = new List<Person>();
    }
}
