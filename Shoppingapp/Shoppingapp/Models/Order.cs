using ShoppingApp.Common;
using ShoppingApp.Enums;

namespace ShoppingApp.Models
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public User? User { get; set; }

        public List<Product> Products { get; set; } = new();
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
    }
}