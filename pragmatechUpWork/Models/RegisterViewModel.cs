using pragmatechUpWork_GeneralLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pragmatechUpWork_CoreMVC.UI.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Bu xana teleb olunur")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu xana teleb olunur")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Xahiş olunur düzgün mail adresi girəsiniz.")]
        public string Email { get; set; }      
    }
}
