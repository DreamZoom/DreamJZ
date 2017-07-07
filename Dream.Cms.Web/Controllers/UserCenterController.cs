using Dream.SSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dream.Cms.Web.Controllers
{
    public class UserCenterController : PassportController
    {
        //
        // GET: /UserCenter/
        [SSO(SSOCenter = "/UserCenter/SignIn")]
        public ActionResult Info()
        {
            var user = SSOProviders.Current.GetUser();
            return View(user);
        }

        [HttpPost]
        public ActionResult Info(SSO.Models.User model)
        {
            var user = SSOProviders.Current.GetUser();
            SSO.Services.UserService userService = new SSO.Services.UserService();
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("模型验证不通过");
                }
                user.NickName = model.NickName;
                user.Mail = model.Mail;
                user.Tell = model.Tell;
                userService.Update(user);

                ViewBag.message = "信息修改成功。";
            }
            catch(Exception err)
            {
                ModelState.AddModelError("", err.Message);
            }
            return View(user);
        }

        [SSO(SSOCenter = "/UserCenter/SignIn")]
        public ActionResult ChangePassword()
        { 
            return View();
        }
        [HttpPost]
        [SSO(SSOCenter = "/UserCenter/SignIn")]
        public ActionResult ChangePassword(string oldpassword,string newpassword)
        {
            var user = SSOProviders.Current.GetUser();
            SSO.Services.UserService userService = new SSO.Services.UserService();
            try
            {
                if (user.Password != oldpassword)
                {
                    throw new Exception("原密码不正确");
                }
                if (string.IsNullOrWhiteSpace(newpassword))
                {
                    throw new Exception("密码不能为空");
                }
                ViewBag.message = "密码修改成功。";
                user.Password = newpassword;
                userService.Update(user);
            }
            catch (Exception err)
            {
                ModelState.AddModelError("", err.Message);
            }
            return View(user);
        }


        public ActionResult LoginOut()
        {
            SSOProviders.Current.LogOut();
            return RedirectToAction("login");
        }

        [SSO(SSOCenter = "/UserCenter/SignIn")]
        public ActionResult JobRecords(int pageIndex=1)
        {
            var user = SSOProviders.Current.GetUser();
            Jobs.Services.JobRecordService recordService = new Jobs.Services.JobRecordService();
            var records = recordService.GetList().Where(m => m.UserID == user.ID).OrderByDescending(m => m.ID).ToPageList(pageIndex, 20);
            return View(records);
        }

        [SSO(SSOCenter = "/UserCenter/SignIn")]
        public ActionResult JobCancel(int Id)
        {
            try
            {
                Jobs.Services.JobRecordService recordService = new Jobs.Services.JobRecordService();
                var record = recordService.FindById(Id);
                record.IsCancel = true;
                record.CreateTime = DateTime.Now;
                recordService.Update(record);
                return  RedirectToAction("JobRecords");
            }
            catch (Exception err)
            {
                ViewBag.message = err.Message;
                return View("error");
            }

        }
    }
}
