using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp1.Services.User
{
    internal interface IUserService
    {
        public void Register();
        public void Login();
        public void logout();
        public void ShowProfile();
    }
}
