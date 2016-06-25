using System.Web.Mvc;

namespace JunDemo.Web.Controllers
{
    public class AboutController : JunDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}