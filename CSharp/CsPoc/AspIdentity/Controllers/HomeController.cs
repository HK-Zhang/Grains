using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AspIdentity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            ViewBag.Country = claimsIdentity.FindFirst(ClaimTypes.Country).Value;

            return View();
        }
    }
}