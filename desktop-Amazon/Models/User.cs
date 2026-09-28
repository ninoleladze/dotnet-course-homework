using Amazon.Common;
using Amazon.Enums;

namespace Amazon.Models
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

