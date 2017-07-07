using Dream.Jobs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;
using Dream.SSO;
using System.Data.Entity.SqlServer;

namespace Dream.Cms.Web.Controllers
{
    [SSO(SSOCenter = "/UserCenter/SignIn")]
    public class UserjobController : Controller
    {
        JobService jobService = new JobService();
        JobTagService jobtagService = new JobTagService();
        WorkareaService wordareaService = new WorkareaService();
        JobRecordService jobRecordService = new JobRecordService();
        public ActionResult Index(int pageIndex = 1)
        {
            ViewBag.tags = jobtagService.GetList().OrderBy(m => m.Sort);
            ViewBag.workarea = wordareaService.GetList().OrderBy(m => m.Sort);

            var list = jobService.GetList(ControllerContext.RequestContext);

            if (!string.IsNullOrWhiteSpace(Request.Params["tagid"]))
            {
                int tagid = int.Parse(Request.Params["tagid"]);
                list = list.Where(m => m.TagID == tagid);
            }

            if (!string.IsNullOrWhiteSpace(Request.Params["areaid"]))
            {
                string areaid = Request.Params["areaid"];
                list = list.Where(m => m.Workareas.Where(n=>n.AreaID.ToString()==areaid).Count()>0);
            }

            var pagelist = list.OrderByDescending(m=>m.IsTop).ThenByDescending(m => m.JobRecords.Where(n=>!n.IsCancel).Count() < m.NeedPeopleCount && m.EndTime > DateTime.Now).ThenBy(m => m.Sort).ThenByDescending(m => m.ID).ToPagedList(pageIndex, 20);
            return View(pagelist);
        }


        public ActionResult Details(int Id)
        {
            var job = jobService.FindById(Id);
            return View(job);
        }

        public static bool eqDate(DateTime t1,DateTime t2)
        {
            return t1.ToShortDateString() == t2.ToShortDateString();
        }
        public ActionResult JoinJob(int Id)
        {
            var job = jobService.FindById(Id);
            var user = SSOProviders.Current.GetUser();

            var old = jobRecordService.GetList().Where(m => !m.IsCancel && m.UserID == user.ID).FirstOrDefault();

            var currentdate = DateTime.Now;
            var cancelListCount = jobRecordService.GetList().Where(m => m.IsCancel && m.UserID == user.ID).Where(m => SqlFunctions.DateDiff("day",m.CreateTime,currentdate)==0).Count();

            if (cancelListCount > 3 && !user.IsProtected)
            {
                ViewBag.message = "对不起，您今天已取消三次报名了，请明天再来。";
            }
            else if(job.IsOver()){
                ViewBag.message = "对不起，报名已结束。";
            }
            else if (old != null)
            {
                //已经报过名了
                ViewBag.message = "对不起，你已经报过名了。";
            }
            else
            {
                var jobs = new Jobs.Models.JobRecord()
                {
                    JobTitle = job.JobName,
                    JobDesc = job.JobDescription,
                    UserID = user.ID,
                    JobID = job.ID,
                    Sort = 99,
                    UserName = user.UserName,
                    Tell=user.Tell,
                    CreateTime = DateTime.Now
                };
                jobRecordService.Create(jobs);
                ViewBag.message = "恭喜你，你已经报名成功。";

                ViewBag.job = job;
                //报名成功
            }

            return View(job);
        }

    }
}
