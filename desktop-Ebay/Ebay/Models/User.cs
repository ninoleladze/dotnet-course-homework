using Ebay.Common;
using Ebay.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebay.Models
{
    internal class User : BaseEntity
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRoles Role { get; set; } = UserRoles.User;

        public bool IsAdmin() => Role == UserRoles.Admin;
    }
}
