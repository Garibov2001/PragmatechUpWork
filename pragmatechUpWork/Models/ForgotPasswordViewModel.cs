using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pragmatechUpWork_CoreMVC.UI.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Bu xana teleb olunur")]
        [EmailAddress(ErrorMessage = "Daxil etdiyiniz email standartlara uyğun gəlmir")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Daxil etdiyiniz email standartlara uyğun gəlmir")]
        public string Email { get; set; }
    }
}
