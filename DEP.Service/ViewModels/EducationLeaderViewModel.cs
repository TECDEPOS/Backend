using DEP.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEP.Service.ViewModels
{
    public class EducationLeaderViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? LocationId { get; set; }
        public int? DepartmentId { get; set; }
        public UserRole UserRole { get; set; }
        public int? EducationBossId { get; set; } //Uddannelseschef

        public Department? Department { get; set; }
        public Location? Location { get; set; }
        public List<Person> Educators { get; set; } = new List<Person>();
    }
}
