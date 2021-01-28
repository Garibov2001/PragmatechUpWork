using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pragmatechUpWork_CoreMVC.UI.Models
{
    public class AllProjectsWithOthers
    {
        public List<Project> projects { get; set; }
        public List<Project> projectsAll { get; set; }
        public List<ProjectTask> projectTasks { get; set; }
        public List<UserApplyAndConfirmTask> appliedTasks { get; set; }

    }
}
