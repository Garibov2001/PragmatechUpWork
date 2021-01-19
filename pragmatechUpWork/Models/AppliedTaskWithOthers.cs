using pragmatechUpWork_CoreMVC.UI.IdentityClasses;
using pragmatechUpWork_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pragmatechUpWork_CoreMVC.UI.Models
{
    public class AppliedTaskWithOthers
    {
        public UserApplyAndConfirmTask applyTask { get; set; }
        public ApplicationUser user { get; set; }
    }
}
