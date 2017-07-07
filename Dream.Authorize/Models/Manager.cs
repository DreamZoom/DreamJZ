using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dream.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Dream.Authorize
{
    public class Manager :EntityBase
    {
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "角色")]
        [Select(Title = "选择角色", Key = "RoleName", KeyTitle = "角色", Name = "RoleName", NameTitle = "角色", ControllerName = "Role")]
        public string RoleName { get; set; }
    }
}
