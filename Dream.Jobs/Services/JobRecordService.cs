using Dream.Jobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dream.Jobs.Services
{
    public class JobRecordService : EntityServiceBase<JobRecord>
    {
        public override IQueryable<JobRecord> GetList(System.Web.Routing.RequestContext context)
        {
            var jobid= context.HttpContext.Request.Params["jobid"];
            if (!string.IsNullOrWhiteSpace(jobid))
            {
                int id = int.Parse(jobid);
                return base.GetList(context).Where(m=>m.JobID==id);
            }

            var userid = context.HttpContext.Request.Params["userid"];
            if (!string.IsNullOrWhiteSpace(userid))
            {
                int uid = int.Parse(userid);
                return base.GetList(context).Where(m => m.UserID == uid);
            }
            return base.GetList(context);
        }
    }
}
