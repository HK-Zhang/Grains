using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/
        public ActionResult Index()
        {
            ViewBag.Number = 8;
            ViewBag.Message = "This is index Page";
            ViewBag.Slarks = new List<string> { "Slark1", "Slark2", "Slark3" };
            return View();
        }
	}
}