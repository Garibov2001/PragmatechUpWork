using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pragmatechUpWork.Models;
using pragmatechUpWork.Utils;

namespace pragmatechUpWork.Controllers
{
    public class ProjectController : Controller
    {
        private readonly Utilities _projectUtil = null;

        public ProjectController(Utilities projectUtil)
        {
            _projectUtil = projectUtil;
        }

        [Route("/projects", Name = "project-whole_projects")]
        public IActionResult WholeProjects()
        {
            return View("whole_projects");
        }

        [Route("/project/{id}", Name = "project-single_project")]
        public async Task<IActionResult> SingleProject(int id)
        {
            ProjectModel projectData = await _projectUtil.GetProject(id);
            return View("single_project", projectData);
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
        public async Task<IActionResult> CreateProject(ProjectModel client_data)
        {
            if (ModelState.IsValid)
            {
                await _projectUtil.AddProject(client_data);
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
            ProjectModel projectData = await _projectUtil.GetProject(id);
            return View("edit_project", projectData);
        }

        [HttpPost]
        [Route("/project/{id}/edit", Name = "project-edit_project")]
        public IActionResult EditProject(int id, ProjectModel client_data)
        {
            if (ModelState.IsValid)
            {
                _projectUtil.EditProject(id, client_data);
                return RedirectToRoute("home-default_page");
            }
            else
            {   
                return View("edit_project");
            }
        }

        [HttpDelete]
        [Route("/project/{id}/remove", Name = "project-remove_project")]
        public IActionResult RemoveProject(int id)
        {
            _projectUtil.RemoveProject(id);
            var responseData = new
            {
                error = "none",
            };

            return Json(responseData);
        }



    }
}
