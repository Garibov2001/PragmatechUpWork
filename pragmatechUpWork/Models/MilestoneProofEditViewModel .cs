using Microsoft.AspNetCore.Http;
using pragmatechUpWork_CoreMVC.UI.IdentityClasses;
using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pragmatechUpWork_CoreMVC.UI.Models
{
    public class MilestoneProofEditViewModel
    {
        public ApplicationUser user;
        public ProjectTask task { get; set; }
        public Project project { get; set; }
        public ProjectTaskMilestone taskMilestone { get; set; }
        public ProjectTaskMilestoneProof milestoneProof { get; set; }
        public IFormFile Image { get; set; }
    }
}
