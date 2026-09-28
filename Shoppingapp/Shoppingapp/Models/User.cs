using ShoppingApp.Common;
using ShoppingApp.Enums;

namespace ShoppingApp.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; 
        public UserRoles Role { get; set; } = UserRoles.Customer;
    }
}