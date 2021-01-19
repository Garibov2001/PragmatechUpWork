using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace pragmatechUpWork_CoreMVC.UI.Controllers
{
    
    [Route("error")]
    [Authorize()]
    public class ErrorController : Controller
    {

        [Route("404")]
        public IActionResult UrlNotFound()
        {
            return View("~/Views/Error/not_fount_error_page.cshtml");
        }
        [Route("500")]
        public IActionResult AppError()
        {
            return View("~/Views/Error/exception_error_page.cshtml");
        }
    }
}
