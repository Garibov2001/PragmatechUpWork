using pragmatechUpWork_GeneralLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace pragmatechUpWork_Entities
{
    public class Project:IEntity
    {
        public int ProjectId { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        [StringLength(75, ErrorMessage = "Adın uzunluğu ən azı {2}, ən çoxu {1} ola bilər.", MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(75, ErrorMessage = "Kateqoriyanın adının uzunluğu ən azı {2}, ən çoxu {1} ola bilər.", MinimumLength = 2)]
        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public string Category { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public int? MinCost { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public int? MaxCost { get; set; }

        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public string ProjectManagerID { get; set; }

        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public DateTime? Advertisement_StartDate { get; set; }

        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public DateTime? Advertisement_EndDate { get; set; }
        [Url(ErrorMessage = "Daxil etdiyiniz URL standartlara uyğun deyil.")]
        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public string GithubUrl { get; set; }

        [StringLength(500, ErrorMessage = "Mətnin uzunluğu ən azı {2}, ən çoxu {1} ola bilər.", MinimumLength = 75)]
        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public string ProjectInfo { get; set; }
        public int Status { get; set; }  // 1 - Aktiv, 2 -Arxiv, 3 - Draft

        //Backref to Tasks
        public ICollection<ProjectTask> Tasks { get; set; }
    }
}
