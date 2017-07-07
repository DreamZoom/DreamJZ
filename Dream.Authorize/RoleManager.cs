using Dream.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Dream.Authorize
{
    public class RoleManager : IManager
    {
        public bool Login(string username, string password)
        {
             ManagerService managerService = new ManagerService();
            var manager = managerService.GetList().FirstOrDefault(m => m.UserName == username);

            byte[] result = Encoding.Default.GetBytes(manager.Password);    //tbPass为输入密码的文本框  
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string enc_password = BitConverter.ToString(output).Replace("-", "");  //tbMd5pass为输出加密文本的

            if (null == manager || enc_password.ToLower() != password) return false;

            System.Web.HttpContext.Current.Session["manager"] = manager;
            return true;
        }

        public bool Logout()
        {
            System.Web.HttpContext.Current.Session["manager"] = null;
            return true;
        }

        public bool ChangePassword(string password, string newpassword)
        {

            if (!CheckLogin()) return false;//未登录，修改失败.

            ManagerService managerService = new ManagerService();

            var manager = System.Web.HttpContext.Current.Session["manager"] as Manager;
            if (null == manager) return false;

            if (manager.Password != password) return false;

            manager.Password = newpassword;

            if (managerService.Update(manager))
            {
                System.Web.HttpContext.Current.Session["manager"] = manager;
                return true;
            }
            return false;
        }
        public bool CheckLogin()
        {
            return System.Web.HttpContext.Current.Session["manager"] != null;
        }
        public string GetRoleName()
        {
            var manager = getManager();
            if (manager == null) return string.Empty;
            return manager.RoleName;
        }

        public string GetUserName()
        {
            var manager = getManager();
            if (manager == null) return string.Empty;
            return manager.UserName;
        }

        public object GetUser()
        {
            return System.Web.HttpContext.Current.Session["manager"];
        }


        private Manager getManager()
        {
            return GetUser() as Manager;
        }


    }
}
