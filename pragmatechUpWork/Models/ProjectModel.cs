﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace pragmatechUpWork.Models
{
    public class ProjectModel
    {
        [Required(ErrorMessage ="Bu xana boş ola bilməz.")]
        [StringLength(75, ErrorMessage = "Adın uzunluğu ən azı {2}, ən çoxu {1} ola bilər.", MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(75, ErrorMessage = "Kateqoriyanın adının uzunluğu ən azı {2}, ən çoxu {1} ola bilər.", MinimumLength = 2)]
        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public string Category { get; set; }


        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public decimal? MinCost { get; set; }

        [Required(ErrorMessage = "Bu xana boş ola bilməz.")]
        public decimal? MaxCost { get; set; }

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
    }
}
