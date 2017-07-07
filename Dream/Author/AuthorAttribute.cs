using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Dream.Author
{
    public class AuthorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = filterContext.ActionDescriptor.ActionName;

            if (AuthorProvider.Author != null)
            {
                var returnUrl = AuthorProvider.Author.ReturnUrl(filterContext.RequestContext);
                var url = filterContext.HttpContext.Request.Url.ToString();

                returnUrl += "?back_url=" + url;

                if (!AuthorProvider.Author.CheckAuthorize(filterContext.RequestContext))
                {
                    filterContext.Result = new RedirectResult(returnUrl);
                    return;
                }
            }


            base.OnActionExecuting(filterContext);
        }
    }
}
