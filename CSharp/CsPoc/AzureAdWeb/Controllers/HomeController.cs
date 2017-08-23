using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AzureAdWeb.AutofacPoc;
using Autofac;


namespace AzureAdWeb.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var claims = ((ClaimsIdentity)User.Identity).Claims;

            return View(claims);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            var a = StaticContainer.ApplicationContainer.Resolve<IPoc>();

            ViewData["Message"] = string.Format("{0},{1}", StaticContainer.ApplicationContainer.GetHashCode(), a.GetHashCode());

            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }
    }
}
