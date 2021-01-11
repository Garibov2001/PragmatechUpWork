using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pragmatechUpWork.Utils;
using pragmatechUpWork_BusinessLogicLayer.UnitOfWork.Abstract;
using pragmatechUpWork_CoreMVC.UI.Models;
using pragmatechUpWork_Entities;

namespace pragmatechUpWork.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUnitOfWork unitofWork = null;

        public ProfileController(IUnitOfWork _unitofWork)
        {
            unitofWork = _unitofWork;
        }


        [Route("/profile/projects", Name = "profile-whole_projects")]
        public async Task<IActionResult> Profile()
        {
            var model = new AllProjectsWithOthers
            {
                projects = await unitofWork.Projects.GetAll()
            };
            return View("profile", model);
        }
    }
}
