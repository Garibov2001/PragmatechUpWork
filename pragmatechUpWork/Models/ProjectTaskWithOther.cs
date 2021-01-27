using Microsoft.AspNetCore.Mvc.Rendering;
using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pragmatechUpWork_CoreMVC.UI.Models
{
    public class ProjectTaskWithOther
    {
        public ProjectTask projectTask { get; set; }
        public SelectList projects { get; set; }
        public Project project { get; set; }
        public UserApplyAndConfirmTask appliedTask { get; set; }
        public ProjectTaskMilestone milestone { get; set; }
    }
}
