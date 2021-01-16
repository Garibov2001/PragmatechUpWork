using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using pragmatechUpWork.Controllers;
using pragmatechUpWork_CoreMVC.UI.IdentityClasses;
using pragmatechUpWork_CoreMVC.UI.Models;
using pragmatechUpWork_Entities;
using pragmatechUpWork_GeneralLayer.Enums;

namespace pragmatechUpWork_CoreMVC.UI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager { get; set; }
        private RoleManager<ApplicationRole> roleManager { get; set; }
        private SignInManager<ApplicationUser> signInManager { get; set; }
        public IConfiguration Configuration { get; }

        public AccountController(
            UserManager<ApplicationUser> _userManager, 
            RoleManager<ApplicationRole> _roleManager,
            SignInManager<ApplicationUser> _signInManager,
            IConfiguration _configuration)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager = _signInManager;
            Configuration = _configuration;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("~/Views/Account/register.cshtml");
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var userApi= GetApiData(register.Email);

                if (userApi!=null)
                {
                    ApplicationUser user = new ApplicationUser()
                    {
                        Name = userApi.Name,
                        Surname = userApi.Surname,
                        UserName = register.UserName,
                        Email = userApi.Email,
                        PhoneNumber = register.PhoneNumber,
                        registerDate = DateTime.Now
                    };
                    IdentityResult result = await userManager.CreateAsync(user, register.Password);

                    if (result.Succeeded)
                    {
                        if(!roleManager.RoleExistsAsync("Admin").Result)
                        {
                            ApplicationRole role = new ApplicationRole
                            {
                                Name = "Admin"
                            };
                            IdentityResult identityResult= roleManager.CreateAsync(role).Result;
                        }

                        userManager.AddToRoleAsync(user,"ADMIN").Wait();

                        return RedirectToAction("Login");
                    }
                    else
                    {
                        return View(register);
                    }
                }
                else
                {
                    return View();
                }
            }
            return View(register);
        }

        [Route("/")]
        public IActionResult Login()
        {
            return View("login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/")]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    return RedirectToRoute("home-default_page");
                }
                else
                {
                    return RedirectToAction("Register");
                }
            }
            else
            {
                return View(loginViewModel);
            }
        }

        public IActionResult SignOut() 
        {
            signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }

        public ApplicationUser GetApiData(string apiUrl)
        {
            //Connect API
            string apUrl = "http://157.230.220.111/api/person?email=" + apiUrl;
            Uri url = new Uri(apUrl);
            WebClient client = new WebClient();

            //var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes("admin:admin123"));
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(
                Configuration["CRM_connection:username"] + ":" + Configuration["CRM_connection:password"]));
            client.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);

            string json = client.DownloadString(url);
            ////END

            ////JSON Parse START
            ApplicationUser user = JsonConvert.DeserializeObject<ApplicationUser>(json);
            ////END

            return user;
        }
    }
}
