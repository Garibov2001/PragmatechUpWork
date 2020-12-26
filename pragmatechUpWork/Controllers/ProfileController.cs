using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace pragmatechUpWork.Controllers
{
    public class ProfileController : Controller
    {
        [Route("/profile", Name = "profile-page")]
        public IActionResult Profile()
        {
            return View("profile");
        }
    }
}
