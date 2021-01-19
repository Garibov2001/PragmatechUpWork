using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pragmatechUpWork_CoreMVC.UI.Models
{
    public class AllProjectTasksWithOthers
    {
        public List<ProjectTask> projecttasks { get; set; }
        public List<Project> projects { get; set; }
        public List<UserApplyAndConfirmTask> appliedTasks { get; set; }

    }
}
