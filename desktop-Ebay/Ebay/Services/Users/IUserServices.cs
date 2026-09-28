using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebay.Services.Users
{
    internal interface IUserServices
    {
        void Register();
        void Login();
        void Logout();
        void ShowProfile();
        void PromoteToAdmin();
    }
}
