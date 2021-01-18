using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pragmatechUpWork_CoreMVC.UI.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Bu xana teleb olunur")]
        [EmailAddress(ErrorMessage = "Daxil etdiyiniz email standartlara uyğun gəlmir")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Daxil etdiyiniz email standartlara uyğun gəlmir")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu xana teleb olunur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bu xana teleb olunur")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifrələr uyğun gəlmir")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}
