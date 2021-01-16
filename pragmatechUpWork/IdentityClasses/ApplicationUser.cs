using Microsoft.AspNetCore.Identity;
using pragmatechUpWork_GeneralLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pragmatechUpWork_CoreMVC.UI.IdentityClasses
{
    public class ApplicationUser:IdentityUser
    {
        public string Surname { get; set; }
        public DateTime registerDate { get; set; }
    }
}
