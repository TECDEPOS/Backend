using DEP.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEP.Service.ViewModels
{
    public class EducationBossViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public UserRole UserRole { get; set; }

        public List<EducationLeaderViewModel> EducationLeaders { get; set; } = new List<EducationLeaderViewModel>();
    }
}
