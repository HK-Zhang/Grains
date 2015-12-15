using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class FirstController : Controller
    {
        //
        // GET: /First/
        //public string Index(string id)
        //{
        //    return "This is first controller index page.<br/> Your Id is " + id;
        //}

        public ActionResult Index()
        {
            return View();
        }

        public string Another() 
        {
            return "This is another page of First controller";
        }
    }

}