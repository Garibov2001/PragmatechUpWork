using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using pragmatechUpWork_CoreMVC.UI.IdentityClasses;
using pragmatechUpWork_CoreMVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pragmatechUpWork_CoreMVC.UI.View_Components
{
    public class UserInformationViewComponent:ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserInformationViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ViewViewComponentResult> InvokeAsync()
        {
            UserDetailsModel model = new UserDetailsModel()
            {
                User = await _userManager.GetUserAsync(HttpContext.User)
            };
            return View(model);
        }
    }
}
