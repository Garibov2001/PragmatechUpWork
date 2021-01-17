using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pragmatechUpWork_BusinessLogicLayer.UnitOfWork.Abstract;
using pragmatechUpWork_CoreMVC.UI.Models;
using pragmatechUpWork_Entities;

namespace pragmatechUpWork.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IUnitOfWork unitofWork = null;

        public ProjectController(IUnitOfWork _unitofWork)
        {
            unitofWork = _unitofWork;
        }

        [Route("/profile/projects", Name = "profile-whole_projects")]
        public async Task<IActionResult> ProfileProjects()
        {
            var model = new AllProjectsWithOthers
            {
                projects = await unitofWork.Projects.GetAll()
            };
            return View("~/Views/Project/profile_projects.cshtml", model);
        }


        [Route("/projects", Name = "project-whole_projects")]
        public async Task<IActionResult> WholeProjects()
        {
            var model = new AllProjectsWithOthers()
            {
                projects = await unitofWork.Projects.GetAllDescending()
            };
            return View("whole_projects",model);
        }

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

        [HttpGet]
        [Route("/project/create", Name = "project-create_project")]
        public IActionResult CreateProject()
        {
            ViewBag.isValidForm = true;
            return View("create_project");
        }

        [HttpPost]
        [Route("/project/create", Name = "project-create_project")]
        public async Task<IActionResult> CreateProject(Project client_data)
        {
            if (ModelState.IsValid)
            {
                await unitofWork.Projects.Add(client_data);
                return RedirectToRoute("home-default_page");
            }
            else
            {
                return View("create_project");
            }
        }

        [HttpGet]
        [Route("/project/{id}/edit", Name = "project-edit_project")]
        public async Task<IActionResult> EditProject(int id)
        {
            var model = new ProjectWithOthers()
            {
                project = await unitofWork.Projects.GetProjectByID(id)
            };

            return View("edit_project", model);
        }

        [HttpPost]
        [Route("/project/{id}/edit", Name = "project-edit_project")]
        public async Task<IActionResult> EditProject(ProjectWithOthers client_data)
        {
            if (ModelState.IsValid)
            {
                await unitofWork.Projects.Update(client_data.project);
                return RedirectToRoute("home-default_page");
            }
            else
            {
                return View("edit_project");
            }
        }

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



}
}
