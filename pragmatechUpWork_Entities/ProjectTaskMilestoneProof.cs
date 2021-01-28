using pragmatechUpWork_GeneralLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace pragmatechUpWork_Entities
{
    public class ProjectTaskMilestoneProof : IEntity
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public string ProofContent { get; set; }

        public string ProofImagePath { get; set; }

        public int MilestoneId { get; set; }
        public ProjectTaskMilestone Milestone { get; set; }
    }
}
