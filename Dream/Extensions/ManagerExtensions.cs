using Dream.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Dream.Extensions
{
    public static  class ManagerExtensions
    {
        public static IManager Manager(this HtmlHelper helper)
        {
            return ManagerProvider.Manager;
        }
    }
}
