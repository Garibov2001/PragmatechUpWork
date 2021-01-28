using pragmatechUpWork_GeneralLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace pragmatechUpWork_Entities
{
    public class ProjectTaskMilestone: IEntity
    {        
        public int ID { get; set; }

        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        [StringLength(75, ErrorMessage = "Taskın adının uzunluğu ən azı {2}, ən çoxu {1} ola bilər.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public DateTime? FinishDate { get; set; }

        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public string MilestoneText { get; set; }

        // 0 - Tamamlanib , 1 - Legv olunub, 2 - Vaxta var , 3 - Vaxti bitib, 4 - Tesdiqlenmeyi gozleyir
        public int Status { get; set; }  
        
        // One-To-Many Relationship
        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public int ProjectTaskId { get; set; }
        public ProjectTask ProjectTask { get; set; }
    }
}


