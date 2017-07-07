using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dream.SSO;

namespace Dream.Cms.Web.Controllers
{
    //[SSO(SSOCenter = "/UserCenter/SignIn")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(SSOProviders.Current.IsLogin()){
                ViewBag.Message = SSOProviders.Current.GetUser().UserName;
            }
            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
