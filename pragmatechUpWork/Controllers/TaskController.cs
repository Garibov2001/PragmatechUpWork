using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pragmatechUpWork.Models;
using Task = pragmatechUpWork.Models.Task;

namespace pragmatechUpWork.Controllers
{
    public class TaskController : Controller
    {
        private readonly UpWorkContext _context = null;
        public TaskController(UpWorkContext argContext)
        {
            _context = argContext;
        }
       
        [HttpGet]
        [Route("/profile/tasks", Name = "profile-whole_tasks")]
        public async Task<IActionResult> ProfileTasks()
        {
            var wholeTasks = await _context.Task.ToListAsync();
            List<Task> tasksDetails = new List<Task>();

            if (wholeTasks?.Any() == true)
            {
                foreach (var project in wholeTasks)
                {
                    tasksDetails.Add(new Task()
                    {
                        TaskId = project.TaskId,
                        Name = project.Name,
                        Cost = project.Cost,
                        RequiredDays = project.RequiredDays,
                        PublishDate = project.PublishDate,
                        GithubUrl = project.GithubUrl,
                        TaskInfo = project.TaskInfo,
                        Status = project.Status,
                        ProjectId = project.ProjectId,
                        Project = await _context.Project.FindAsync(project.ProjectId),                        
                    });
                }
            }
            return View("profile_tasks", tasksDetails);
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


        [HttpGet]
        [Route("/task/{id}/edit", Name = "task-edit_task")]
        public async Task<IActionResult> EditTask(int id)
        {
            var task = await _context.Task.FindAsync(id);

            if (task != null)
            {
                var taskDetails = new Task()
                {
                    Name = task.Name,
                    Cost = task.Cost,
                    RequiredDays = task.RequiredDays,
                    PublishDate = task.PublishDate,
                    GithubUrl = task.GithubUrl,
                    TaskInfo = task.TaskInfo,
                    Status = task.Status,
                    Project = await _context.Project.FindAsync(task.ProjectId),
                    ProjectId = task.ProjectId,
                };

                var options = new SelectList(_context.Project, nameof(Project.ProjectId), nameof(Project.Name), taskDetails.ProjectId);
                ViewBag.options = options;

                return View("edit_task", taskDetails);
            }
            else
            {
                return NotFound();
            }

        }


        [HttpPost]
        [Route("/task/{id}/edit", Name = "task-edit_task")]
        public async Task<IActionResult> EditTask(int id, Task client_data)
        {
            if (ModelState.IsValid)
            {
                var oldTask = _context.Task.FirstOrDefault(e => e.TaskId == id);
                if (oldTask == null)
                {
                    return NotFound();
                }
                else
                {
                    oldTask.Name = client_data.Name;
                    oldTask.Cost = client_data.Cost;
                    oldTask.RequiredDays = client_data.RequiredDays;
                    oldTask.GithubUrl = client_data.GithubUrl;
                    oldTask.TaskInfo = client_data.TaskInfo;
                    oldTask.Status = client_data.Status;
                    oldTask.Project = await _context.Project.FindAsync(client_data.ProjectId);
                    oldTask.ProjectId = client_data.ProjectId;

                    await _context.SaveChangesAsync();
                    return RedirectToRoute("profile-whole_tasks");
                }
            }
            else
            {
                var options = new SelectList(_context.Project, nameof(Project.ProjectId), nameof(Project.Name), client_data.ProjectId);
                ViewBag.options = options;
                return View("edit_task");
            }           
        }


        [HttpDelete]
        [Route("/task/{id}/remove", Name = "task-remove_task")]
        public IActionResult RemoveProject(int id)
        {
            var task = _context.Task.FirstOrDefault(e => e.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }
            else
            {
                _context.Task.Remove(task);
                _context.SaveChanges();
            }
            var responseData = new
            {
                error = "none",
            };

            return Json(responseData);
        }

    }
}
