using Dream.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dream.SSO.Models
{
    public class User :EntityBase
    {
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Display(Name = "昵称")]
        [UIHint("NickName")]
        public string NickName { get; set; }

        [Display(Name = "密码")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [UIHint("PasswordD")]
        public string Password { get; set; }

        [Display(Name = "邮箱")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        public string Mail { get; set; }
        [Display(Name = "电话")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.PhoneNumber)]
        [RegularExpression(@"^1[3-9][0-9]{9}$", ErrorMessage = "手机号格式不正确")]
        public string Tell { get; set; }

        [Display(Name = "到期时间")]
        [UIHint("DateTimeViald")]
        public DateTime EndTime { get; set; }

        [Display(Name = "内部成员")]
        [Switch(Yes = "是", No = "否")]
        public bool IsProtected { get; set; }
    }
}
