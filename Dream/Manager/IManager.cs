


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dream.Manager
{
    public interface IManager
    {
        bool Login(string username,string password);

        bool Logout();

        bool ChangePassword(string password, string newpassword);

        bool CheckLogin();

        string GetRoleName();

        string GetUserName();

        object GetUser();

    }
}
