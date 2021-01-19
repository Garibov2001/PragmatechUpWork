using Microsoft.AspNetCore.Mvc.Rendering;
using pragmatechUpWork_CoreMVC.UI.IdentityClasses;
using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pragmatechUpWork_CoreMVC.UI.Models
{
    public class ProjectWithOthers
    {
        public Project project { get; set; }
        public List<ProjectTask> projectTasks { get; set; }
        public SelectList ProjectManagers { get; set; }
    }
}
