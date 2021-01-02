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
        public async Task<IActionResult> CreateTask(Task client_post)
        {            
            if (ModelState.IsValid)
            {
                var newTask = new Task()
                {
                    Name = client_post.Name,
                    Cost = client_post.Cost,
                    RequiredDays = client_post.RequiredDays,
                    PublishDate = DateTime.Now,
                    GithubUrl = client_post.GithubUrl,
                    TaskInfo = client_post.TaskInfo,
                    Status = 0,
                    Project = await _context.Project.FindAsync(client_post.ProjectId),
                    ProjectId = client_post.ProjectId,
                };

                await _context.Task.AddAsync(newTask);
                await _context.SaveChangesAsync();

                return RedirectToRoute("home-default_page");
            }
            else
            {
                var options = new SelectList(_context.Project, nameof(Project.ProjectId), nameof(Project.Name));
                ViewBag.options = options;
                return View("create_task");
            }
        }



    }
}
