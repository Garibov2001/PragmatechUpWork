using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using pragmatechUpWork_CoreMVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pragmatechUpWork_CoreMVC.UI.View_Components
{
    public class UserInformationViewComponent:ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            UserDetailsModel model = new UserDetailsModel()
            {
                Username = HttpContext.User.Identity.Name
            };
            return View(model);
        }
    }
}
