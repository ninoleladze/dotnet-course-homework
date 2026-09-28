using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._24._26.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();



    }
}
