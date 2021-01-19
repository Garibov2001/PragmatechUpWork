using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pragmatechUpWork_BusinessLogicLayer.UnitOfWork.Abstract;
using pragmatechUpWork_CoreMVC.UI.IdentityClasses;
using pragmatechUpWork_CoreMVC.UI.Models;
using pragmatechUpWork_Entities;
using pragmatechUpWork_GeneralLayer.Enums;
using pragmatechUpWork_NotificationServices.Abstract;
using pragmatechUpWork_NotificationServices.General;

namespace pragmatechUpWork.Controllers
{
    public class TaskController : Controller
    {
        private readonly IUnitOfWork unitofWork = null;
        private UserManager<ApplicationUser> userManager { get; set; }
        private IEmailService emailService;

        public TaskController(IUnitOfWork _unitofWork, UserManager<ApplicationUser> _userManager,IEmailService _emailService)
        {
            unitofWork = _unitofWork;
            userManager = _userManager;
            emailService = _emailService;
        }
        [Authorize()]
        [HttpGet]
        [Route("/profile/tasks", Name = "profile-whole_tasks")]
        public async Task<IActionResult> ProfileTasks()
        {
            var currentUser = await userManager.GetUserAsync(User);
            var roles = await userManager.GetRolesAsync(currentUser);
            var model = new AllProjectTasksWithOthers();

            if (roles.Contains(UserRolesEnum.Müəllim.ToString()))
            {
                var projectTasks = await unitofWork.ProjectTasks.GetAll();

                if (projectTasks.Any())
                {
                    foreach (var projectTask in projectTasks)
                    {
                        projectTask.Project = await unitofWork.Projects.GetProjectByID(projectTask.ProjectId);
                    }
                }

                model.projecttasks = projectTasks;
            }
            else
            {
                var appliedTasks = await unitofWork.AplliedTasks.GetAppliedTasksByUserID(currentUser.Id);

                if (appliedTasks.Any())
                {
                    foreach (var appliedTask in appliedTasks)
                    {
                        appliedTask.Task = await unitofWork.ProjectTasks.GetTasksByID(appliedTask.TaskID);
                        appliedTask.Task.Project = await unitofWork.Projects.GetProjectByID(appliedTask.Task.ProjectId);
                    }
                }

                model.appliedTasks = appliedTasks;
            }            

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

        //Elave olunacaq
        [Authorize()]
        [HttpGet]
        [Route("/applied/tasks", Name = "project-applied_task")]
        public async Task<IActionResult> AppliedTasks()
        {
            var appliedTasks = await unitofWork.AplliedTasks.GetAppliedTasksByStatus(false);

            if (appliedTasks.Any())
            {
                foreach (var appliedTask in appliedTasks)
                {
                    appliedTask.Task = await unitofWork.ProjectTasks.GetTasksByID(appliedTask.TaskID);
                }
            }

            var model = new AllApliedTasksWithOthers()
            {
                appliedTasks = appliedTasks,
                appliedTask=new UserApplyAndConfirmTask()
            };
            return View("applied_tasks", model);
        }

        //Elave olunacaq
        [Authorize()]
        [HttpGet]
        [Route("/single_applied/tasks/{id}", Name = "single-applied_task")]
        public async Task<IActionResult> Single_AppliedTasks(int id)
        {
            var appliedTask = await unitofWork.AplliedTasks.GetAppliedTasksByID(id);

            if (appliedTask!=null)
            {
                    appliedTask.Task = await unitofWork.ProjectTasks.GetTasksByID(appliedTask.TaskID);
            }

            var model = new AppliedTaskWithOthers()
            {
                applyTask = appliedTask,
                user = userManager.FindByIdAsync(appliedTask.UserID).Result
            };
            return View("single_appliedtask", model);
        }

        //Elave olunacaq
        [Authorize()]
        [HttpPost]
        [Route("/confirmed/tasks", Name = "project-confirmed_task")]
        public async Task<IActionResult> ConfirmTask(AppliedTaskWithOthers appliedTask)
        {
            ProjectTask task= await unitofWork.ProjectTasks.GetTasksByID(appliedTask.applyTask.TaskID);

            appliedTask.applyTask.Task = task;
            appliedTask.applyTask.Status = true;

            var user = userManager.FindByIdAsync(appliedTask.applyTask.UserID).Result;

            bool result=await unitofWork.AplliedTasks.Update(appliedTask.applyTask);
            if (result==true)
            {
                EmailGonder(user.Email, user.Name, task.Name);
            }

            return RedirectToRoute("project-applied_task");
        }

        //Elave olunacaq
        private void EmailGonder(string targetEmail,string user,string taskName)
        {
            string subject = "Pragmatech Task Teklifi Qebulu";
            string body = string.Format("{0} bəy {1} taskı hakkındakı teklifiniz müdüriyyət tərəfindən qebul olundu.Taskı qeyd etdiyiniz vaxtda tehvil vermeyiniz xahis olunur.",user,taskName);
            var message = new Message(
                new string[] { $"{targetEmail}" }, subject, body);
            emailService.SendEmail(message);
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

            var model = new ProjectTaskWithOther()
            {
                projectTask = task,
                project = await unitofWork.Projects.GetProjectByTask(task),
                appliedTask = new UserApplyAndConfirmTask()

            };

            if (ModelState.IsValid)
            {
                appliedTask.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                appliedTask.TaskID = id;
                appliedTask.Task = task;
                appliedTask.ApplyDate = DateTime.Now;

                bool result=await unitofWork.AplliedTasks.Add(appliedTask);
                model.appliedTask = appliedTask;

                ViewBag.Success = true;
                return View("single_task", model);
            }
            else
            {
                return View("single_task", model);                
            }            
        }

        [Authorize()]
        [HttpGet]
        [Route("/task/create", Name = "task-create_task")]
        public async Task<IActionResult> CreateTask()
        {
            var Projects = await unitofWork.Projects.GetAll();

            var model = new ProjectTaskWithOther()
            {
                projects = new SelectList(Projects, nameof(Project.ProjectId), nameof(Project.Name)),
                projectTask=new ProjectTask()
            };
            ViewBag.ProjectTask = model.projects;

            return View("create_task", model);
        }

        [Authorize()]
        [HttpPost]
        [Route("/task/create", Name = "task-create_task")]
        public async Task<IActionResult> CreateTask(ProjectTaskWithOther client_post)
        {
            if (ModelState.IsValid)
            {
                var project = await unitofWork.Projects.GetProjectByID(client_post.projectTask.ProjectId);
                client_post.projectTask.Project = project;
                client_post.projectTask.Status = 0;

                await unitofWork.ProjectTasks.Add(client_post.projectTask);

                return RedirectToRoute("profile-whole_tasks");
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
