using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Dream.Author
{
    public interface IAuthor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestContext"></param>
        /// <returns></returns>
        bool CheckAuthorize(RequestContext requestContext);

        /// <summary>
        /// 跳转登录页
        /// </summary>
        /// <param name="requestContext"></param>
        /// <returns></returns>
        string ReturnUrl(RequestContext requestContext);
    }
}
