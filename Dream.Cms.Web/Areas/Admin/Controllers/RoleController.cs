using Dream.Authorize;
using Dream.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dream.Cms.Web.Areas.Admin.Controllers
{
    public class RoleController : ManageControllerBase<RoleService, Role>
    {
        
        public ActionResult getAuths()
        {
            var config = ConfigProvider.Load<MenuConfig>();

            List<object> list = ComboxChildTree(config.Menus);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public List<object> ComboxChildTree(List<MenuNode> nodes)
        {
            List<object> list = new List<object>();
            foreach (var item in nodes)
            {
                list.Add(new { id = item.Name, text = item.Name, children = ComboxChildTree(item.Menus) });
            }
            return list;
        }

    }
}
