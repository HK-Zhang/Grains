using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class PartialViewController : Controller
    {
        //
        // GET: /PartialView/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Default()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ChildAction(DateTime time)
        {
            string greeting = string.Empty;

            if (time.Hour > 18)
            {
                greeting = "Good evening. Now is "+time.ToString("HH:mm:ss");
            }
            else if (time.Hour > 12)
            {
                greeting = "Good evening. Now is " + time.ToString("HH:mm:ss");
            }
            else
            {
                greeting = "Good evening. Now is " + time.ToString("HH:mm:ss");
            }

            return PartialView("ChildAction", greeting);
        }


        public PartialViewResult AjaxChildAction(DateTime time)
        {
            string greeting = string.Empty;

            if (time.Hour > 18)
            {
                greeting = "Good evening. Now is " + time.ToString("HH:mm:ss");
            }
            else if (time.Hour > 12)
            {
                greeting = "Good evening. Now is " + time.ToString("HH:mm:ss");
            }
            else
            {
                greeting = "Good evening. Now is " + time.ToString("HH:mm:ss");
            }

            return PartialView("ChildAction", greeting);
        }
	}
}