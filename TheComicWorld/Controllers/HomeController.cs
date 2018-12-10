using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheComicWorld.Models;
using TheComicWorld.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace TheComicWorld.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("Home");
        }

        private Dictionary<string, object> GetData(string actionName) =>
            new Dictionary<string, object>
            {
                ["Action"] = actionName,
                ["User"] = HttpContext.User.Identity.Name,
                ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
                ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
                ["In Users Role"] = HttpContext.User.IsInRole("Users")
            };
    }
}
