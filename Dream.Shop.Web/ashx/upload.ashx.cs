using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dream.Cms.Web.ashx
{
    /// <summary>
    /// upload 的摘要说明
    /// </summary>
    public class upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.Files.Count == 0)
            {
                context.Response.Write("error");
                context.Response.End();
            }
            var file = context.Request.Files[0];
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}