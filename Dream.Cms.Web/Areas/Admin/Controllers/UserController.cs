using Dream.SSO.Models;
using Dream.SSO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dream.Cms.Web.Areas.Admin.Controllers
{
    public class UserController : ManageControllerBase<UserService, User>
    {
        //
        // GET: /Admin/User/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getUsersByDay()
        {
            var list = Service.GetList().OrderByDescending(m => m.ID).Take(2000).OrderBy(m => m.ID).ToList().GroupBy(m => m.CreateTime.Date).Select(g => (new { name = g.Key, count = g.Count() })).Take(2000).OrderBy(m=>m.name);
            return JsonP(list);
        }

    }
}
