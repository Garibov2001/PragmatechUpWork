using pragmatechUpWork_CoreMVC.UI.IdentityClasses;
using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pragmatechUpWork_CoreMVC.UI.Models
{
    public class AllProjectTaskMilestoneProofsWithOthers
    {
        public ApplicationUser user;
        public ProjectTask task { get; set; }
        public Project project { get; set; }
        public ProjectTaskMilestone taskMilestone { get; set; }
        public List<ProjectTaskMilestoneProof> milestoneProofs { get; set; }
    }
}
