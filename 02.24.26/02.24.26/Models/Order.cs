using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._24._26.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}

enum OrderStatus
{
    Pending,
    Done,
    Rejected
}