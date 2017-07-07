using Dream.Jobs.Models;
using Dream.Jobs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dream.Cms.Web.Areas.Admin.Controllers
{
    public class JobRecordController : ManageControllerBase<JobRecordService, JobRecord>
    {
        //
        // GET: /Admin/JobRecord/

        public ActionResult getRecordsByDay()
        {
            var list = Service.GetList().OrderByDescending(m=>m.ID).Take(2000).OrderBy(m=>m.ID).ToList().GroupBy(m => m.CreateTime.Date).Select(g => (new { name = g.Key, count = g.Count() })).OrderBy(m=>m.name);
            return JsonP(list);
        }

        public ActionResult getRecordCountByUser(int userid)
        {
            var listCount = Service.GetList().Where(m => m.UserID == userid).Count();
            return JsonP(new { result=true,count=listCount});
        }



    }
}
