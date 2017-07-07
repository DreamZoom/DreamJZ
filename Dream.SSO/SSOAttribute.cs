using Dream.SSO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Dream.SSO
{
    public class SSOAttribute : ActionFilterAttribute
    {
        public string SSOCenter { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = SSOProviders.Current.GetUser();
            if (user==null )
            {
                var token = filterContext.HttpContext.Request.Params["token"];
                User tokenUser=null;
                if (string.IsNullOrWhiteSpace(token) || (tokenUser = SSOProviders.Current.GetUserByToken(token)) == null)
                {
                    string backurl = filterContext.HttpContext.Request.Url.AbsolutePath;
                    string splitStr = SSOCenter.Contains("?") ? "&" : "?";
                    string returnFormat = "{0}{1}ReturnUrl={2}";
                    filterContext.Result = new RedirectResult(string.Format(returnFormat, SSOCenter, splitStr, backurl));
                }
                else
                {
                    SSOProviders.Current.LogIn(tokenUser);
                }
                
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
