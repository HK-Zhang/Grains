using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JunDemo.APPLEs.Dto;
using JunDemo.APPLEs;

namespace JunDemo.Web.Controllers
{
    public class APPLEEmpController : JunDemoControllerBase
    {

        private readonly IEmpAppService _empAppService;

        public APPLEEmpController(IEmpAppService empAppService)
        {
            _empAppService = empAppService;
        }

        //
        // GET: /APPLEEmp/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddEmp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmp(EmpDto dto)
        {
            _empAppService.CreateEmp(dto);
            return View();
        }

        public string TellMeDate() 
        {
            return DateTime.Today.ToString();
        }

        public string WelcomeMsg(string input) 
        {
            if (string.IsNullOrEmpty(input)) 
            {
                return "Please enter your name.";
            }
            else
            {
                
                return "Please welcome " + input + ".";
            }
        }

        public JsonResult EmpList(string city)
        {
            GetEmpsInput input = new GetEmpsInput { City = city };
            var tmp = Json(_empAppService.GetEmps(input).Emps, JsonRequestBehavior.AllowGet);

            return tmp;
        }

        public Abp.Web.Mvc.Controllers.Results.AbpJsonResult AbpEmpList(string city)
        {
            GetEmpsInput input = new GetEmpsInput { City = city };
            var tmp = new Abp.Web.Mvc.Controllers.Results.AbpJsonResult(_empAppService.GetEmps(input).Emps);
            tmp.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return tmp;
        }

        public Abp.Web.Mvc.Controllers.Results.AbpJsonResult AbpEmpListWithInput(GetEmpsInput input)
        {
            var tmp = new Abp.Web.Mvc.Controllers.Results.AbpJsonResult(_empAppService.GetEmps(input).Emps);
            tmp.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return tmp;
        }

        public ActionResult About()
        {

            List<string> cities = new List<string> { "shanghai","beijin" };
            ViewBag.City = cities;
            return View();
        }

        public ActionResult UpdateEmp()
        {
            return View();
        }

        [HttpPost]
        public string SubmitSubscription(string Name, string Address)
        {
            if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Address))
                //TODO: Save the data in database
                return "Thank you " + Name + ". Record Saved.";
            else
                return "Please complete the form.";

        }

        [HttpPost]
        public string SubmitSubscriptionWithObj(EmpDto input)
        {
            if (!String.IsNullOrEmpty(input.Name) && !String.IsNullOrEmpty(input.Address))
                //TODO: Save the data in database
                return "Thank you " + input.Name + ". Record Saved.";
            else
                return "Please complete the form.";

        }

        public ActionResult HtmlHelp() 
        {
            return View();
        }
	}
}