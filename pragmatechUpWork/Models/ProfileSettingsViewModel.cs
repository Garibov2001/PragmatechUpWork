using pragmatechUpWork_CoreMVC.UI.IdentityClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pragmatechUpWork_CoreMVC.UI.Models
{
    public class ProfileSettingsViewModel
    {
        public ApplicationUser User { get; set; }
        public IList<string> UserRoles { get; internal set; }

        [Required(ErrorMessage = "Bu xana teleb olunur")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Bu xana teleb olunur")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Bu xana teleb olunur")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Şifrələr bir-biriylə uyuşmur.")]
        public string ConfirmNewPassword { get; set; }
    }
}
