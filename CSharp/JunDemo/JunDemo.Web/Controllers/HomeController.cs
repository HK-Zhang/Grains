using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace JunDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : JunDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}