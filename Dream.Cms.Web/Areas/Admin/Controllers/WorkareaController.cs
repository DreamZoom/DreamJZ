using Dream.Jobs.Models;
using Dream.Jobs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dream.Cms.Web.Areas.Admin.Controllers
{
    public class WorkareaController : ManageControllerBase<WorkareaService, Workarea>
    {
        //
        // GET: /Admin/Workarea/

        public ActionResult Index()
        {
            return View();
        }

    }
}
