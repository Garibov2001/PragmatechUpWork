using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace pragmatechUpWork.Controllers
{
    public class TaskController : Controller
    {       
        public TaskController()
        {
        }

        [Route("/tasks", Name = "tasks-page")]
        public IActionResult Tasks()
        {
            return View("tasks");
        }


    }
}
