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
        [Route("/register",Name ="user-register")]
        public IActionResult Register()
        {
            return View("~/Views/Account/register.cshtml");
        }

        [ValidateAntiForgeryToken] 
        [HttpPost]
        [Route("/register", Name = "user-register")]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var userApi= GetApiData(register.Email);

                if (userApi!=null)
                {
                    ApplicationUser user = new ApplicationUser()
                    {
                        Name = userApi.name,
                        Surname = userApi.surname,
                        Father_name = userApi.father_name,
                        UserName = register.UserName,
                        Email = userApi.email,
                        registerDate = DateTime.Now
                    };
                    IdentityResult result = await userManager.CreateAsync(user, register.Password);

                    if (result.Succeeded)
                    {
                        string roleName = String.Empty;
                        int roleNumber;
                        foreach (string character in userApi.roles)
                        {                           
                            if (int.TryParse(character, out roleNumber))
                            {
                                if (roleNumber == (int)UserRolesEnum.Müəllim)
                                {
                                    roleName = UserRolesEnum.Müəllim.ToString();
                                    break;
                                }
                                else if(roleNumber == (int)UserRolesEnum.Proqramçı)
                                {
                                    roleName = UserRolesEnum.Proqramçı.ToString();
                                    break;
                                }
                                else if (roleNumber == (int)UserRolesEnum.Dəstək_Komandası)
                                {
                                    roleName = UserRolesEnum.Dəstək_Komandası.ToString();
                                    break;
                                }
                                else if (roleNumber == (int)UserRolesEnum.Menecment)
                                {
                                    roleName = UserRolesEnum.Menecment.ToString();
                                    break;
                                }
                                else if (roleNumber == (int)UserRolesEnum.Tələbə)
                                {
                                    roleName = UserRolesEnum.Tələbə.ToString();
                                    break;
                                }
                            }
                        }

                        if(!roleManager.RoleExistsAsync(roleName).Result)
                        {
                            ApplicationRole role = new ApplicationRole
                            {
                                Name = roleName
                            };
                            IdentityResult identityResult= roleManager.CreateAsync(role).Result;
                        }

                        userManager.AddToRoleAsync(user, roleName).Wait();

                        return RedirectToAction("Login");
                    }
                    else
                    {
                        var errors = result.Errors.ToList();

                        foreach (var error in errors)
                        {
                            switch (error.Code)
                            {
                                case "DuplicateUserName":
                                    ModelState.AddModelError("UserName", error.Description);
                                    break;
                                case "DuplicateEmail":
                                    ModelState.AddModelError("Email", error.Description);
                                    break;
                                default:
                                    ModelState.AddModelError("", error.Description);
                                    break;
                            }
                        }

                        return View("~/Views/Account/register.cshtml", register);
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Daxil etdiyiniz email CRM sistemində yoxdur");
                    return View("~/Views/Account/register.cshtml", register);
                }
            }
            return View("~/Views/Account/register.cshtml", register);
        }

        [Route("/", Name ="user-login")]
        public IActionResult Login()
        {
            return View("login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/", Name = "user-login")]
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
                    ModelState.AddModelError("", "Daxil etdiyiniz username və ya şifrə düzgün deyil.");
                    return View("login", loginViewModel);
                }
            }
            else
            {
                return View("login", loginViewModel);
            }
        }

        [HttpGet]
        [Route("/signout", Name = "user-signout")]
        public IActionResult SignOut() 
        {
            signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }

        public dynamic GetApiData(string apiUrl)
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
            dynamic userData = JsonConvert.DeserializeObject<dynamic>(json);

            ////END

            return userData;
        }
    }
}
