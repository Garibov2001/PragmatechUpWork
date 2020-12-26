using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace pragmatechUpWork.Controllers
{
    public class ProjectController : Controller
    {

        [Route("/projects", Name = "project-whole_projects")]
        public IActionResult WholeProjects()
        {
            return View("whole_projects");
        }

        [Route("/project/{id}")]
        public ViewResult SingleProject(int id)
        {
            ViewBag.id = id;
            return View("single_project");
        }
    }
}
