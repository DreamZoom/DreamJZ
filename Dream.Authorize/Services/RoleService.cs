using Dream.Config;
using Dream.Utility;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Dream.Authorize
{
    public class RoleService : EntityServiceBase<Role>
    {
      
        /// <summary>
        /// 判断角色是否存在
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public virtual Role Exists(string roleName)
        {
            var role = this.GetList().FirstOrDefault(m => m.RoleName == roleName);
            return role;
        }

        public override bool Create(Role entity)
        {
            if (Exists(entity.RoleName)!=null)
            {
                throw new ArgumentException("角色已经存在");
            }
            return base.Create(entity);
        }

        public override bool Update(Role entity)
        {
            var role=Exists(entity.RoleName);
            if (role != null && role.ID != entity.ID)
            {
                throw new ArgumentException("角色已经存在");
            }
            return base.Update(entity);
        }

        private NameValueCollection getParams(string keyValues)
        {
            Check.CheckNull(keyValues);
            NameValueCollection nv = new NameValueCollection();
            var kvList = keyValues.Split(',');
            foreach (var item in kvList)
            {
                var kv = item.Split('=');
                if (kv.Length != 2) continue;
                nv.Add(kv[0],kv[1]);
            }
            return nv;
        }
        public virtual bool CheckAuthorize(string roleName,string areaName,string controllerName,string actionName,NameValueCollection paramData)
        {
            Check.CheckNull(roleName);
            var menuConfig = ConfigProvider.Load<MenuConfig>();
            var menu = menuConfig.Find(areaName, controllerName, actionName, paramData);
            var role = this.Exists(roleName);

            if (role != null && menu != null && role.RoleAuths.Split(',').Contains(menu.Name)) return true;
            if (menu == null)
            {
                return true;
            }
            return false;
        }
    }
}
