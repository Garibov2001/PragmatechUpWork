using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pragmatechUpWork_BusinessLogicLayer.UnitOfWork.Abstract;
using pragmatechUpWork_CoreMVC.UI.Models;
using pragmatechUpWork_Entities;

namespace pragmatechUpWork.Controllers
{
    public class TaskController : Controller
    {
        private readonly IUnitOfWork unitofWork = null;

        public TaskController(IUnitOfWork _unitofWork)
        {
            unitofWork = _unitofWork;
        }
        [Authorize()]
        [HttpGet]
        [Route("/profile/tasks", Name = "profile-whole_tasks")]
        public async Task<IActionResult> ProfileTasks()
        {
            var projectTasks = await unitofWork.ProjectTasks.GetAll();

            if (projectTasks.Any())
            {
                foreach (var projectTask in projectTasks)
                {
                    projectTask.Project = await unitofWork.Projects.GetProjectByID(projectTask.ProjectId);
                }
            }

            var model = new AllProjectTasksWithOthers()
            {
                projecttasks = projectTasks
            };
            return View("profile_tasks", model);
        }

        [Authorize()]
        [HttpGet]
        [Route("/tasks", Name = "task-whole_task")]
        public async Task<IActionResult> WholeTasks()
        {
            var projectTasks = await unitofWork.ProjectTasks.GetAllDescending();

            if (projectTasks.Any())
            {
                foreach (var projectTask in projectTasks)
                {
                    projectTask.Project = await unitofWork.Projects.GetProjectByID(projectTask.ProjectId);
                }
            }

            var model = new AllProjectTasksWithOthers()
            {
                projecttasks = projectTasks
            };
            return View("whole_tasks", model);
        }

        [HttpGet]
        [Route("/task/{id}", Name = "task-single_task")]
        public async Task<IActionResult> SingleTask(int id)
        {
            ProjectTask task = await unitofWork.ProjectTasks.GetTasksByID(id);
            var model = new ProjectTaskWithOther()
            {
                projectTask=task,
                project = await unitofWork.Projects.GetProjectByTask(task),
                appliedTask = new UserApplyAndConfirmTask()
            };

            return View("single_task", model);
        }



        [HttpPost]
        [Route("/task/{id}", Name = "task-single_task")]
        public async Task<IActionResult> SingleTask(int id, UserApplyAndConfirmTask appliedTask)
        {
            ProjectTask task = await unitofWork.ProjectTasks.GetTasksByID(id);

            appliedTask.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await unitofWork.AplliedTasks.Add(appliedTask);

            var model = new ProjectTaskWithOther()
            {
                projectTask = task,
                project = await unitofWork.Projects.GetProjectByTask(task),
                appliedTask = new UserApplyAndConfirmTask()

            };
            return View("single_task", model);
        }

        [Authorize()]
        [HttpGet]
        [Route("/task/create", Name = "task-create_task")]
        public async Task<IActionResult> CreateTask()
        {
            var Projects = await unitofWork.Projects.GetAll();

            var projectTaskWithOther = new ProjectTaskWithOther()
            {
                projects = new SelectList(Projects, nameof(Project.ProjectId), nameof(Project.Name)),
                projectTask=new ProjectTask()
            };
            ViewBag.ProjectTask = projectTaskWithOther.projects;
            return View("create_task");
        }

        [Authorize()]
        [HttpPost]
        [Route("/task/create", Name = "task-create_task")]
        public async Task<IActionResult> CreateTask(ProjectTask client_post)
        {
            if (ModelState.IsValid)
            {
                var project = await unitofWork.Projects.GetProjectByID(client_post.ProjectId);
                client_post.Project = project;
                client_post.Status = 0;

                await unitofWork.ProjectTasks.Add(client_post);

                return RedirectToRoute("home-default_page");
            }
            else
            {
                var Projects = await unitofWork.Projects.GetAll();

                var model = new ProjectTaskWithOther()
                {
                    projects = new SelectList(Projects, nameof(Project.ProjectId), nameof(Project.Name))
                };
                return View("create_task", model);
            }
        }

        [Authorize()]
        [HttpGet]
        [Route("/task/{id}/edit", Name = "task-edit_task")]
        public async Task<IActionResult> EditTask(int id)
        {
            var projectTask = await unitofWork.ProjectTasks.GetTasksByID(id);

            if (projectTask != null)
            {
                projectTask.Project = await unitofWork.Projects.GetProjectByID(projectTask.ProjectId);

                var Projects = await unitofWork.Projects.GetAll();

                var projectTaskWithOther = new ProjectTaskWithOther()
                {
                    projects = new SelectList(Projects, nameof(Project.ProjectId), nameof(Project.Name),projectTask.ProjectId),
                };
                ViewBag.Projects = projectTaskWithOther.projects;
                var model = projectTask;
                return View("edit_task", model);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize()]
        [HttpPost]
        [Route("/task/{id}/edit", Name = "task-edit_task")]
        public async Task<IActionResult> EditTask(int id, ProjectTask client_data)
        {
            if (ModelState.IsValid)
            {
                if (client_data == null)
                {
                    return NotFound();
                }
                else
                {
                    client_data.Project = await unitofWork.Projects.GetProjectByID(client_data.ProjectId);

                    await unitofWork.ProjectTasks.Update(client_data);
                    return RedirectToRoute("profile-whole_tasks");
                }
            }
            else
            {
                var Projects = await unitofWork.Projects.GetAll();

                var model = new ProjectTaskWithOther()
                {
                    projects = new SelectList(Projects, nameof(Project.ProjectId), nameof(Project.Name), client_data.ProjectId),
                };
                return View("edit_task", model);
            }
        }

        [Authorize()]
        [HttpDelete]
        [Route("/task/{id}/remove", Name = "task-remove_task")]
        public async Task<IActionResult> RemoveProject(int id)
        {
            var projecttask = await unitofWork.ProjectTasks.GetTasksByID(id);
            if (projecttask == null)
            {
                return NotFound();
            }
            else
            {
                await unitofWork.ProjectTasks.Delete(id);
            }
            var responseData = new
            {
                error = "none",
            };

            return Json(responseData);
        }

    }
}
