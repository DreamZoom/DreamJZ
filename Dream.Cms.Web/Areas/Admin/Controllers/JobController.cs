using Dream.Jobs.Models;
using Dream.Jobs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace Dream.Cms.Web.Areas.Admin.Controllers
{
    public class JobController : ManageControllerBase<JobService, Job>
    {
        //
        // GET: /Admin/Job/

        public ActionResult Index()
        {
            return View();
        }

        public override ActionResult PageList(int page = 1, int rows = 10)
        {
            var list = Service.GetList(ControllerContext.RequestContext).OrderByDescending(m => m.IsTop).ThenByDescending(m => m.JobRecords.Where(n=>!n.IsCancel).Count() < m.NeedPeopleCount && m.EndTime > DateTime.Now).ThenBy(m => m.Sort).ThenByDescending(m => m.ID).ToPagedList(page, rows);
            return JsonP(new { rows = list, total = list.TotalItemCount });
        }
        public ActionResult GetJobing()
        {
            var listCount = Service.GetList(ControllerContext.RequestContext).Where(m => m.JobRecords.Where(n=>!n.IsCancel).Count() < m.NeedPeopleCount && m.EndTime > DateTime.Now).Count();
            return JsonP(new { result=true,count=listCount });
        }
    }
}
