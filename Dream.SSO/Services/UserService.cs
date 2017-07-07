using Dream.SSO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dream.SSO.Services
{
    public class UserService : EntityServiceBase<User>
    {
        public User GetUserByName(string username)
        {
            return this.GetList().Where(m => m.UserName == username).FirstOrDefault();
        }

        public override bool Create(User entity)
        {
           var user  =this.GetUserByName(entity.UserName);
           if (user != null)
           {
               throw new Exception("用户名已存在，请另外输入。");
           }
            return base.Create(entity);
        }
    }
}
