using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class DefaultControllerController : Controller
    {
        //
        // GET: /DefaultController/
        public ActionResult DefaultAction()
        {
            Simple s = new Simple();
            s.Name = "Hello World";
            s.Email = "abc@163.com";
            return View(s);
        }
	}
}