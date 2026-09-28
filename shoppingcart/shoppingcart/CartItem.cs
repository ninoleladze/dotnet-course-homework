using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppingcart
{
    internal class CartItem
    {
         private static int _counter = 1;

     public int Id { get; set; }
     public int Quantity { get; set; }
     public Product Product { get; set; }

    

     public CartItem()
        {
            Id = _counter++;
        }

    public override string ToString()
    {
       
            return $"{Id}. {Product.Name} - {Product.Description} - {Product.category} - ${Product.Price} - Quantity: {Quantity}";
        }
    }


}
