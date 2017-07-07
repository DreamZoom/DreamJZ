using Dream.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Dream.Extensions
{
    public static class MenuConfigExtensions
    {

        static MenuConfig menuConfig = null;
        public static MenuConfig MenuConfig(this HtmlHelper helper)
        {
            //if (menuConfig == null)
            {
                menuConfig = ConfigProvider.Load<MenuConfig>();
            }
            return menuConfig;
        }

        public static List<MenuNode> Breadcrumbs(this HtmlHelper helper)
        {
            List<MenuNode> list = new List<MenuNode>();
            MenuConfig config = helper.MenuConfig();

            var node = config.Menus.FirstOrDefault(m => m.IsCurrent(helper.ViewContext.RequestContext));

            while (node != null)
            {
                list.Add(node);
                node = node.Menus.FirstOrDefault(m => m.IsCurrent(helper.ViewContext.RequestContext));
            }

            return list;
        }
    }

}
