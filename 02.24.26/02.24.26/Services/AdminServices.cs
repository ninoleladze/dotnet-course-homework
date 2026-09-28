using _02._24._26.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._24._26.Services
{
    internal class AdminServices
    {
        DataContext DC = new DataContext();

        public void GetProductsWithCategory() {
       
            var productsWithCategory = DC.Products
                .Include(p=> p.Category)
                .ToList();
    
                foreach (var item in productsWithCategory)
                {
                    Console.WriteLine($"Product: {item.ProductName}, Category: {item.CategoryName}");
            }
        }
        public void GetCategoryWithProducts() {
        
            var categoryWithProducts = DC.Categories
                .Include(c => c.Products)
                .ToList();
    
                foreach (var item in categoryWithProducts)
                {
                    Console.WriteLine($"Category: {item.CategoryName}");
                    foreach (var product in item.Products)
                    {
                        Console.WriteLine($" - Product: {product}");
                    }
            }
        }
        public void GetOrders() {]
            var orders= DC.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .ToList();
    
                foreach (var order in orders)
                {
                    Console.WriteLine($"Id: {order.Id} , status{order.Status.ToString()}");
                    Console.WriteLine($"User: {order.User.Username}, email: {order.User.Email}");
                    foreach (var item in order.OrderItems)
                    {
                        Console.WriteLine($" - Product: {item.Id}, Quantity: {item.Quantity}");
                        Console.WriteLine($"product: name:{item.Product.Name},price: {item.Product.Price}");
                }
            }



        }
}
