using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        //[Authorize(Roles ="Admin")]
        [HttpGet]
        [Route("/profile", Name = "profile-account-page")]
        public async Task<IActionResult> Profile()
        {
            return View("~/Views/Profile/account_page.cshtml");
        }



    }
}
