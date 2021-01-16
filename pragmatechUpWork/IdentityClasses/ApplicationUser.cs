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
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Father_name { get; set; }
        public DateTime registerDate { get; set; }
    }
}
