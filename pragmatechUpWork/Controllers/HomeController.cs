using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pragmatechUpWork_BusinessLogicLayer.UnitOfWork.Abstract;
using pragmatechUpWork_CoreMVC.UI.Models;

namespace pragmatechUpWork.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork unitofWork = null;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork _unitofWork)
        {
            unitofWork = _unitofWork;
            _logger = logger;
        }
        [Authorize()]
        [Route("/home", Name = "home-default_page")]
        public async Task<IActionResult> Home()
        {
            var model = new AllProjectsWithOthers()
            {
                projects = await unitofWork.Projects.GetLastProjectsForCounter(5),
                projectsAll=await unitofWork.Projects.GetAll(),
                projectTasks=await unitofWork.ProjectTasks.GetLastProjectTaskForCounter(5)
            };
            return View("home",model);
        }              
    }
}
