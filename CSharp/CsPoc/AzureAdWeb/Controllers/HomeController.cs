using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AzureAdWeb.AutofacPoc;
using Autofac;
using Microsoft.Extensions.DependencyInjection;


namespace AzureAdWeb.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private IPoc ppoc;
        public HomeController(IPoc poc)
        {
            ppoc = poc;
        }
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
            var c = HttpContext.RequestServices.GetRequiredService<IPoc>();
            var a = StaticContainer.ApplicationContainer.Resolve<IPoc>();

            ViewData["Message"] = string.Format("{0},{1},{2}.{3}", StaticContainer.ApplicationContainer.GetHashCode(), a.GetHashCode(), ppoc.GetHashCode(),c.GetHashCode());

            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }
    }
}
