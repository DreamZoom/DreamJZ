using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dream.Cms.Site.Areas.Admin.Controllers
{
    public class CategoryController : ManageControllerBase<CategoryService, Category>
    {
        //
        // GET: /Admin/Category/

        public ActionResult Index()
        {
            return View();
        }

    }
}
