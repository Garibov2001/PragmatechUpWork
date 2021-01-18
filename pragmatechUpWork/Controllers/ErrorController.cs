using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace pragmatechUpWork_CoreMVC.UI.Controllers
{
    [Route("error")]
    public class ErrorController : Controller
    {

        [Route("404")]
        public IActionResult UrlNotFound()
        {
            return View("~/Views/Error/not_fount_error_page.cshtml");
        }
    }
}
