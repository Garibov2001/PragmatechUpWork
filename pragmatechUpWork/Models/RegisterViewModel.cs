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
        [DataType(DataType.EmailAddress,ErrorMessage ="Xahiş olunur düzgün mail adresi girəsiniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu xana teleb olunur")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Xahiş olunur düzgün telefon nomresi girəsiniz.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Bu xana teleb olunur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bu xana teleb olunur")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
