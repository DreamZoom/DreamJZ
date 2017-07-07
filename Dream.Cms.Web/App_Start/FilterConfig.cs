using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Dream.Cms.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomHandleErrorAttribute());
        }
    }

    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            File.AppendAllText(filterContext.HttpContext.Server.MapPath("/log.txt"), filterContext.Exception.Message);
            base.OnException(filterContext);
        }
    }
}