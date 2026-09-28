using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._21.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();




        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Price: {Price:C}, Category: {Category}, Description: {Description}";
        }


    }
}
