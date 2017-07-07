using Dream.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dream.Extensions;

namespace Dream.Cms.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
           
            return View();
        }



        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login(string password){
            return View();
        }

    }
}
