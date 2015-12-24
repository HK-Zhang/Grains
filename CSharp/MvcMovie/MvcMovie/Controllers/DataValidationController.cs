using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;
using System.Text.RegularExpressions;

namespace MvcMovie.Controllers
{
    public class DataValidationController : Controller
    {
        //
        // GET: /DataValidation/
        public ActionResult ModelStateAction()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ModelStateAction(ModelStateModel model)
        {
            if (string.IsNullOrEmpty(model.Name)) 
            {
                ModelState.AddModelError("Name", "Name is required");
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("Email", "Email is required");
            }
            else {
                string expression = @"^\s*([A-Za-z0-9_-]+(\.\w+)*@([\w-]+\.)+\w{2,3})\s*$";
                Regex reg = new Regex(expression);
                if (!reg.IsMatch(model.Email)) 
                {
                    ModelState.AddModelError("Email", "Email is invalid");
                }
            }

            if (ModelState.IsValid) 
            {
                ViewBag.Name = model.Name;
                ViewBag.Email = model.Email;
            }

            return View(model);
        }


        public ActionResult DataAnnotationAction()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DataAnnotationAction(DAModelStateModel model)
        {
            if (ModelState.IsValid) 
            {
                ViewBag.Name = model.Name;
                ViewBag.Email = model.Email;

            }
            return View(model);
        }
	}
}