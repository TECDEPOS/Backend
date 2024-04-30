using DEP.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEP.Service.ViewModels
{
    public class ModuleWithCourseViewModel
    {
        public int ModuleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
