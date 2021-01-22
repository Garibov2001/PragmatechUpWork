using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using pragmatechUpWork_BusinessLogicLayer.UnitOfWork.Abstract;
using pragmatechUpWork_CoreMVC.UI.IdentityClasses;
using pragmatechUpWork_CoreMVC.UI.Models;
using pragmatechUpWork_Entities;
using pragmatechUpWork_GeneralLayer.Enums;

namespace pragmatechUpWork.Controllers
{

    public class ProjectController : Controller
    {
        private readonly IUnitOfWork unitofWork = null;
        private UserManager<ApplicationUser> userManager { get; set; }
        private RoleManager<ApplicationRole> roleManager { get; set; }

        public ProjectController(IUnitOfWork _unitofWork, UserManager<ApplicationUser> _userManager, RoleManager<ApplicationRole> _roleManager)
        {
            unitofWork = _unitofWork;
            userManager = _userManager;
            roleManager = _roleManager;
        }

        [Authorize()]
        [Route("/profile/projects", Name = "profile-whole_projects")]
        public async Task<IActionResult> ProfileProjects()
        {
            //Active Page
            ViewBag.ProjectsPage = true;
            
            var currentUser = await userManager.GetUserAsync(User);
            var roles = await userManager.GetRolesAsync(currentUser);
            var model = new AllProjectsWithOthers();

            if (roles.Contains(UserRolesEnum.Müəllim.ToString()))
            {
                var projects = await unitofWork.Projects.GetAll();

                model.projects = projects;
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

            return View("profile_projects", model);
        }

        [Authorize()]
        [Route("/projects", Name = "project-whole_projects")]
        public async Task<IActionResult> WholeProjects()
        {
            var model = new AllProjectsWithOthers()
            {
                projects = await unitofWork.Projects.GetAllDescending()
            };
            return View("whole_projects",model);
        }

        [Authorize()]
        [Route("/project/{id}", Name = "project-single_project")]
        public async Task<IActionResult> SingleProject(int id)
        {
            var model = new ProjectWithOthers()
            {
                project = await unitofWork.Projects.GetProjectByID(id),
                projectTasks = await unitofWork.ProjectTasks.GetTasksByProjet(id)
            };
            return View("single_project", model);
        }

        [Authorize()]
        [HttpGet]
        [Route("/project/create", Name = "project-create_project")]
        public async Task<IActionResult> CreateProject()
        {
            //Active Page
            ViewBag.ProjectsPage = true;

            var projectManagers = await GetProjectManagers();           

            var model = new ProjectWithOthers 
            { 
                ProjectManagers = new SelectList(projectManagers, nameof(ApplicationUser.Id), nameof(ApplicationUser.Name))
            };

            return View("create_project", model);
        }

        [Authorize()]
        [HttpPost]
        [Route("/project/create", Name = "project-create_project")]
        public async Task<IActionResult> CreateProject(ProjectWithOthers client_data)
        {
            //Active Page
            ViewBag.ProjectsPage = true;

            var projectManagers = await GetProjectManagers();

            var model = new ProjectWithOthers
            {
                project = new Project(),
                ProjectManagers = new SelectList(projectManagers, nameof(ApplicationUser.Id), nameof(ApplicationUser.Name))
            };


            if (ModelState.IsValid)
            {
                await unitofWork.Projects.Add(client_data.project);
                return RedirectToRoute("profile-whole_projects");
            }
            else
            {
                return View("create_project", model);
            }
        }

        [Authorize()]
        [HttpGet]
        [Route("/project/{id}/edit", Name = "project-edit_project")]
        public async Task<IActionResult> EditProject(int id)
        {
            //Active Page
            ViewBag.ProjectsPage = true;

            var projectManagers = await GetProjectManagers();
            var project = await unitofWork.Projects.GetProjectByID(id);
            var model = new ProjectWithOthers()
            {
                project = project,
                ProjectManagers = new SelectList(projectManagers, nameof(ApplicationUser.Id), nameof(ApplicationUser.Name), project.ProjectManagerID)
            };

            return View("edit_project", model);
        }

        [Authorize()]
        [HttpPost]
        [Route("/project/{id}/edit", Name = "project-edit_project")]
        public async Task<IActionResult> EditProject(ProjectWithOthers client_data)
        {
            //Active Page
            ViewBag.ProjectsPage = true;

            var projectManagers = await GetProjectManagers();
            var model = new ProjectWithOthers()
            {
                project = client_data.project,
                ProjectManagers = new SelectList(projectManagers, nameof(ApplicationUser.Id), nameof(ApplicationUser.Name), client_data.project.ProjectManagerID)
            };

            if (ModelState.IsValid)
            {
                await unitofWork.Projects.Update(client_data.project);
                return RedirectToRoute("profile-whole_projects");
            }
            else
            {
                return View("edit_project", model);
            }
        }

        [Authorize()]
        [HttpDelete]
        [Route("/project/{id}/remove", Name = "project-remove_project")]
        public async Task<IActionResult> RemoveProject(int id)
        {
            await unitofWork.Projects.Delete(id);
            var responseData = new
            {
                error = "none",
            };

        return Json(responseData);
        }

        private async Task<List<ApplicationUser>> GetProjectManagers() 
        {
            List<string> roles = new List<string>();
            roles.Add(UserRolesEnum.Müəllim.ToString());
            roles.Add(UserRolesEnum.Proqramçı.ToString());
            roles.Add(UserRolesEnum.Dəstək_Komandası.ToString());

            List<ApplicationUser> projectManagers = new List<ApplicationUser>();

            foreach (var role in roles)
            {
                var usersInRole = await userManager.GetUsersInRoleAsync(role);
                foreach (var user in usersInRole)
                {
                    projectManagers.Add(user);
                }
            }

            return projectManagers;
        }



}
}
