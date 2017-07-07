using Dream.SSO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dream.SSO
{
    public interface ISSOProvider
    {
        User GetUser();

        User GetUserByToken(string token);

        bool IsLogin();

        void LogIn(User user);


        void LogOut();
        
    }
}
