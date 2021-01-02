using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace pragmatechUpWork.Models
{
    public class Task
    {
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        [StringLength(75, ErrorMessage = "Taskın adının uzunluğu ən azı {2}, ən çoxu {1} ola bilər.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public int? Cost { get; set; }

        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public int? RequiredDays { get; set; }

        public DateTime? PublishDate { get; set; }

        [Url(ErrorMessage = "Daxil etdiyiniz URL standartlara uyğun deyil.")]
        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public string GithubUrl { get; set; }

        [StringLength(500, ErrorMessage = "Mətnin uzunluğu ən azı {2}, ən çoxu {1} ola bilər.", MinimumLength = 75)]
        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public string TaskInfo { get; set; }
        public int Status { get; set; }  // 0 - Aktiv, 1 - Verilmiş, 2 -Arxiv, 3 - Draft

        // One-To-Many Relationship
        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }

    public enum TaskStatusEnum
    {
        Aktiv = 0,
        Verilmiş = 1,
        Arxiv = 2,
        Draft = 3,
    }

}
