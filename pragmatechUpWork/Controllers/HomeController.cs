using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace pragmatechUpWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("/", Name = "home-page")]
        public IActionResult Home()
        {
            return View("home");
        }

        [Route("/projects", Name ="projects-page")]
        public IActionResult Projects()
        {
            return View("projects");
        }

        [Route("/tasks", Name = "tasks-page")]
        public IActionResult Tasks()
        {
            return View("tasks");
        }

        [Route("/profile", Name = "profile-page")]
        public IActionResult Profile()
        {
            return View("profile");
        }


    }
}
