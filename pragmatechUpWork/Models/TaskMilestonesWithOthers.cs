using pragmatechUpWork_Entities;
using System.Collections.Generic;

namespace pragmatechUpWork_CoreMVC.UI.Models
{
    public class TaskMilestonesWithOthers
    {
        public List<ProjectTaskMilestone> TaskMilestones { get; set; }
        public ProjectTaskMilestone milestone { get; set; }
        public ProjectTask projectTask { get; set; }
        public Project project { get; set; }
    }
}