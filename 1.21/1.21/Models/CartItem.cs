using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._21.Models
{
    internal class CartItem
    {
      
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }  
        public int ProductId { get; set; }
        public Product Product { get; set; }



    }
}
