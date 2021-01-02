using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pragmatechUpWork.Models;
using pragmatechUpWork.Utils;

namespace pragmatechUpWork.Controllers
{
    public class ProfileController : Controller
    {
        private readonly Utilities _projectUtil = null;

        public ProfileController(Utilities projectUtil)
        {
            _projectUtil = projectUtil;
        }


        [Route("/profile/projects", Name = "profile-whole_projects")]
        public async Task<IActionResult> Profile()
        {
            List<Project> projects = await _projectUtil.GetWholeProjects();
            return View("profile", projects);
        }
    }
}
