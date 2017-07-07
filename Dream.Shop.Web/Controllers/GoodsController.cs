using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dream.Shop.Web.Controllers
{
    public class GoodsController : DataManagerControllerBase<good_service, goods>
    {
        //
        // GET: /Goods/

        public ActionResult Index()
        {
            return View();
        }

    }
}
