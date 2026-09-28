using ShoppingApp.Common;

namespace ShoppingApp.Models
{
    public class Cart : BaseEntity
    {
        public int UserId { get; set; }
        public User? User { get; set; }

        public List<Product> Products { get; set; } = new();
    }
}