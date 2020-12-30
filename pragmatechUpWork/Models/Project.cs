using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace pragmatechUpWork.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bu xana boş ola bilməz.")]
        [StringLength(75, ErrorMessage = "Adın uzunluğu ən azı {2}, ən çoxu {1} ola bilər.", MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(75, ErrorMessage = "Kateqoriyanın adının uzunluğu ən azı {2}, ən çoxu {1} ola bilər.", MinimumLength = 2)]
        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public int? MinCost { get; set; }

        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public int? MaxCost { get; set; }

        public string ProjectManager { get; set; }

        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public DateTime? EndDate { get; set; }

        [Url(ErrorMessage = "Daxil etdiyiniz URL standartlara uyğun deyil.")]
        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public string GithubUrl { get; set; }

        [StringLength(500, ErrorMessage = "Mətnin uzunluğu ən azı {2}, ən çoxu {1} ola bilər.", MinimumLength = 75)]
        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public string ProjectInfo { get; set; }
        public int Status { get; set; }  // 1 - Aktiv, 2 -Arxiv, 3 - Draft
    }
}
