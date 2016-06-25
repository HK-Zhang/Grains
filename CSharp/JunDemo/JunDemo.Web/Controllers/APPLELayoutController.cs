using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JunDemo.Web.Controllers
{
    public class APPLELayoutController : Controller
    {
        //
        // GET: /APPLELayout/
        //LayoutDemo_01
        public ActionResult LayoutDemo_01()
        {
            ViewBag.Title = "布局页一";
            return View();
        }

        //LayoutDemo_02
        public ActionResult LayoutDemo_02()
        {
            ViewBag.Title = "布局页二";
            return View();
        }

        public ActionResult LayoutDeom_03()
        {
            ViewBag.Title = "布局页三";
            return View();
        }
	}
}