using Dream.SSO.Models;
using Dream.SSO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dream.SSO
{
    public class SSOProvider : ISSOProvider
    {

        public User GetUser()
        {
            var user = System.Web.HttpContext.Current.Session["ssouser"] as User;
            return user;
        }

        public void LogIn(User user)
        {
            System.Web.HttpContext.Current.Session["ssouser"] = user;
        }

        public void LogOut()
        {
            System.Web.HttpContext.Current.Session["ssouser"] = null;
        }

        public bool IsLogin()
        {
            return GetUser() != null;
        }





        public User GetUserByToken(string token)
        {
            TokenService tokenService = new TokenService();
            UserService userService = new UserService();
            var tokenEntity =tokenService.GetList().Where(m => m.TokenID == token).FirstOrDefault();
            if (tokenEntity == null) return null;
            return userService.GetUserByName(tokenEntity.UserName);
        }
    }
}
