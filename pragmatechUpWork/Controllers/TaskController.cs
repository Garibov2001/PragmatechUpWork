using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using pragmatechUpWork.Models;
using Task = pragmatechUpWork.Models.Task;

namespace pragmatechUpWork.Controllers
{
    public class TaskController : Controller
    {
        private readonly DbConnections _context = null;
        public TaskController(DbConnections argContext)
        {
            _context = argContext;
        }

        


        [HttpGet]
        [Route("/profile/tasks", Name = "profile-whole_tasks")]
        public IActionResult GetWholeProjects()
        {
            return View("create_task");
        }

        [HttpGet]
        [Route("/task/create", Name = "task-create_task")]
        public IActionResult CreateTask()
        {
            var options = new SelectList(_context.Project, nameof(Project.ProjectId), nameof(Project.Name));
            ViewBag.options = options;
            return View("create_task");
        }


        [HttpPost]
        [Route("/task/create", Name = "task-create_task")]
        public IActionResult CreateTask(Task client_post)
        {
            var options = new SelectList(_context.Project, nameof(Project.ProjectId), nameof(Project.Name));
            ViewBag.options = options;

            if (ModelState.IsValid)
            {
                return RedirectToRoute("home-default_page");
            }
            else
            {
                return View("create_task");
            }
        }


    }
}
