using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dream.Cms.Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string searchText, int pageIndex=1)
        {
            ArticleService articleService = new ArticleService();
            var qlist = articleService.GetList();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                qlist = qlist.Where(m => m.Name.Contains(searchText));
            }
            var  list=qlist.OrderByDescending(m=>m.CreateTime).ToPageList(pageIndex, 20);
            return View(list);
        }

        public ActionResult Details(int Id)
        {
            ArticleService articleService = new ArticleService();
            var a = articleService.Get(Id);
            return View(a);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

    }
}
