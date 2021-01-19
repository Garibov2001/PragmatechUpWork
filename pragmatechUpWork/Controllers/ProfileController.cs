using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using pragmatechUpWork_BusinessLogicLayer.UnitOfWork.Abstract;
using pragmatechUpWork_CoreMVC.UI.IdentityClasses;
using pragmatechUpWork_CoreMVC.UI.Models;
using pragmatechUpWork_Entities;

namespace pragmatechUpWork.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUnitOfWork unitofWork = null;
        private UserManager<ApplicationUser> userManager { get; set; }

        public ProfileController(IUnitOfWork _unitofWork, UserManager<ApplicationUser> _userManager)
        {
            unitofWork = _unitofWork;
            userManager = _userManager;
        }

        //[Authorize(Roles ="Admin")]
        [HttpGet]
        [Route("/profile", Name = "profile-account-page")]
        public async Task<IActionResult> Profile()
        {
            return View("~/Views/Profile/account_page.cshtml");
        }

        [HttpGet]
        [Route("/profile/settings", Name = "profile-settings-page")]
        public async Task<IActionResult> ProfileSettings()
        {
            var currentUser = await userManager.GetUserAsync(User);
            var roles = await userManager.GetRolesAsync(currentUser);
            var model = new ProfileSettingsViewModel
            {
                User = currentUser,
                UserRoles = roles,
            };            

            return View("~/Views/Profile/settings_page.cshtml", model);
        }

        [HttpPost]
        [Route("/profile/settings", Name = "profile-settings-page")]
        public async Task<IActionResult> ProfileSettings(ProfileSettingsViewModel client_data)
        {
            var currentUser = await userManager.GetUserAsync(User);
            var roles = await userManager.GetRolesAsync(currentUser);
            var model = new ProfileSettingsViewModel
            {
                User = currentUser,
                UserRoles = roles,
            };

            if (ModelState.IsValid)
            {
                var result = await userManager.ChangePasswordAsync(currentUser, client_data.OldPassword, client_data.NewPassword);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View("~/Views/Profile/settings_page.cshtml", model);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("OldPassword", error.Description);
                    }

                    return View("~/Views/Profile/settings_page.cshtml", model);
                }

            }
            else
            {
                return View("~/Views/Profile/settings_page.cshtml", model); 
            }

        }


    }
}
