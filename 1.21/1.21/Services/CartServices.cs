using _1._21.Data;
using _1._21.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._21.Services
{
    internal class CartServices
    {
        private DataContext DC = new DataContext();
        private ProductServices ProductServices = new ProductServices();
       
        public void AddToCart() {
            ProductServices.CheckLoggedIn();
             
            ProductServices.GetAllProducts();
            Console.WriteLine("Enter product id: ");
            int id = int.Parse(Console.ReadLine());
            var product = DC.Products.Find(id);
            if (product != null) throw new Exception("product not found.");
            if(product.StockQuantity <=0) throw new Exception("product out of stock.");

            var existingCartItem = DC.CartItems
                .FirstOrDefault(c => c.ProductId == product.Id && c.UserId == UserServices.loggedInUser.Id);

            if(existingCartItem==null) 
            {
                CartItem item = new CartItem()
                {
                    ProductId = product.Id,
                    UserId = UserServices.loggedInUser.Id,
                    Quantity = 1,

                };

                DC.CartItems.Add(item);

            }
            else { existingCartItem.Quantity += 1; }



            DC.SaveChanges();

            Console.WriteLine("success");
        }
        public void RemoveFromCart() { 
            ProductServices.CheckLoggedIn();
            ShowUserCart();
            Console.WriteLine("Enter product id to remove: ");
            int id = int.Parse(Console.ReadLine());
            var cartItem = DC.CartItems
                .Include(c => c.Product)
                .FirstOrDefault(c => c.Id == id);
            if (cartItem == null) throw new Exception("item not found in cart.");
            if(cartItem.UserId != UserServices.loggedInUser.Id) throw new Exception("you are not authorized to remove this item.");

            cartItem.Product.StockQuantity += cartItem.Quantity;

            DC.CartItems.Remove(cartItem);
            DC.SaveChanges();
            Console.WriteLine("success");

        }
        public void UpdateCart() {
            ProductServices.CheckLoggedIn();
            ShowUserCart();
            Console.WriteLine("Enter product id to remove: ");
            int id = int.Parse(Console.ReadLine());
            var cartItem = DC.CartItems
                .Include(c => c.Product)
                .FirstOrDefault(c => c.Id == id);
            if (cartItem == null) throw new Exception("item not found in cart.");
            if (cartItem.UserId != UserServices.loggedInUser.Id) throw new Exception("you are not authorized ");
            Console.WriteLine("Enter new quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            if(quantity <1 || quantity > 99) throw new Exception("quantity must be between 1 and 99.");
            if(cartItem.Product.StockQuantity - quantity <0) throw new Exception("not enough stock.");
            cartItem.Quantity = quantity;
            cartItem.Product.StockQuantity -= quantity;
            DC.SaveChanges();
            Console.WriteLine("success");


        }
        public void ShowUserCart() {
        
            ProductServices.CheckLoggedIn();
            var cartItems = DC.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == UserServices.loggedInUser.Id)
                .ToList();
            if (cartItems.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                return;
            }
            else
            {
                Console.WriteLine("Your cart items:");
                foreach (var item in cartItems)
                {
                    Console.WriteLine($"Product: {item.Product}, Quantity: {item.Quantity}, ");
                }
            }
        }

    }
}
