using Dream.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Dream
{
    public class MainController : Controller
    {
        [Author.Author]
        public ActionResult Center()
        {
            return View();
        }
        public virtual ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Login(string userName, string password, string back_url = null)
        {
            if (ManagerProvider.Manager.Login(userName, password))
            {
                if (string.IsNullOrWhiteSpace(back_url))
                {
                    return RedirectToAction("center");
                }
                return Redirect(back_url);
            }
            ModelState.AddModelError("", "用户名或密码错误，登录失败。");
            return View();
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            ManagerProvider.Manager.Logout();
            return RedirectToAction("Login");
        }


        [Author.Author]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Author.Author]
        public ActionResult ChangePassword(string password, string newpassword)
        {
            if (ManagerProvider.Manager.ChangePassword(password, newpassword))
            {
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "密码修改失败，可能是密码输入错误。");
            return View();
        }
    }
}
