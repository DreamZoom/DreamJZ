using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dream.Authorize
{
    public class Role  : EntityBase
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        /// 
        [Display(Name = "角色名")]
        public string RoleName { get; set; }


        /// <summary>
        /// 逗号分隔的菜单项
        /// </summary>
        /// 
        [Display(Name = "权限")]
        [UIHint("RoleAuths")]
        public string RoleAuths { get; set; }
    }
}
