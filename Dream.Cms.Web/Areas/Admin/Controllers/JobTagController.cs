using Dream.Jobs.Models;
using Dream.Jobs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dream.Cms.Web.Areas.Admin.Controllers
{
    public class JobTagController : ManageControllerBase<JobTagService, JobTag>
    {
        //
        // GET: /Admin/JobTag/

        public ActionResult Index()
        {
            return View();
        }

    }
}
