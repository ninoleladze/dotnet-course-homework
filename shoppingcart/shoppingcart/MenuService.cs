using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppingcart
{
    internal class MenuService
    {
        private List<CartItem> cart = new List<CartItem>();
        private List<Product> products = new List<Product>()
        {
            new Product(){Name="Iphone 14", Description="Apple Iphone 14", category="Electronics", Price=999.99},
            new Product(){Name="Samsung Galaxy S23", Description="Samsung Galaxy S23", category="Electronics", Price=899.99},
            new Product(){Name="Sony WH-1000XM4", Description="Sony Noise Cancelling Headphones", category="Electronics", Price=349.99},
            new Product(){Name="Dell XPS 13", Description="Dell XPS 13 Laptop", category="Computers", Price=1199.99},
            new Product(){Name="MacBook Pro", Description="Apple MacBook Pro 16-inch", category="Computers", Price=2499.99},
            new Product(){Name="Nike Air Max 270", Description="Nike Air Max 270 Shoes", category="Footwear", Price=150.00},
            new Product(){Name="Adidas Ultraboost", Description="Adidas Ultraboost Shoes", category="Footwear", Price=180.00},
            new Product(){Name="The Alchemist", Description="Book by Paulo Coelho", category="Books", Price=15.99},
            new Product(){Name="Becoming", Description="Book by Michelle Obama", category="Books", Price=19.99},
            new Product(){Name="Instant Pot Duo", Description="Instant Pot 7-in-1 Electric Pressure Cooker", category="Home Appliances", Price=89.99}
        };
        private bool isOpen = true;

        public void Start()
        {
            while (isOpen)
            {
                Console.WriteLine("1. add to cart");
                Console.WriteLine("2. remove cart");
                Console.WriteLine("3. show cart");
                Console.WriteLine("4. show products");
                Console.WriteLine("5. edit quantity");
                Console.WriteLine("Enter key: ");
                string key = Console.ReadLine();

                switch (key)
                {
                    case "1":
                        AddToCart();
                        break;
                    case "2":
                        RemoveFromCart();
                        break;
                    case "3":
                        ShowCart();
                        break;
                    case "4":
                        ShowProducts();
                        break;
                    case "5":
                        EditQuantity();
                        break;
                    default:
                        isOpen = false;
                        break;
                }
            }
        }

        private void AddToCart()
        {
            ShowProducts();
            try
            {
                Console.WriteLine();
                Console.Write("Enter product id to add to cart: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid product id.");
                    return;
                }

                Console.Write("Enter Quantity: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid quantity. Must be a positive integer.");
                    return;
                }

                var product = products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                    return;
                }

                var existing = cart.FirstOrDefault(ci => ci.Product.Id == id);
                if (existing != null)
                {
                    existing.Quantity += quantity;
                    Console.WriteLine("Existing cart item quantity updated.");
                }
                else
                {
                    CartItem cartItem = new CartItem()
                    {
                        Quantity = quantity,
                        Product = product
                    };
                    cart.Add(cartItem);
                    Console.WriteLine("Product added to cart successfully.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private void RemoveFromCart()
        {
            ShowCart();
            try
            {
                Console.WriteLine();
                Console.Write("Enter cart item id to remove from cart: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid id.");
                    return;
                }

                var item = cart.FirstOrDefault(ci => ci.Id == id);
                if (item == null)
                {
                    Console.WriteLine("Cart item not found.");
                    return;
                }

                cart.Remove(item);
                Console.WriteLine("Product removed from cart successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private void EditQuantity()
        {
            ShowCart();
            try
            {
                Console.WriteLine();
                Console.Write("Enter cart item id to edit quantity: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid id.");
                    return;
                }

                var item = cart.FirstOrDefault(ci => ci.Id == id);
                if (item == null)
                {
                    Console.WriteLine("Cart item not found.");
                    return;
                }

                Console.Write($"Current quantity: {item.Quantity}. Enter new quantity: ");
                if (!int.TryParse(Console.ReadLine(), out int newQty))
                {
                    Console.WriteLine("Invalid quantity.");
                    return;
                }

                if (newQty <= 0)
                {
                    Console.WriteLine("Quantity must be greater than zero. To remove the item use option 2.");
                    return;
                }

                item.Quantity = newQty;
                Console.WriteLine("Quantity updated successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private void ShowProducts()
        {
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
        }

        private void ShowCart()
        {
            if (!cart.Any())
            {
                Console.WriteLine("Cart is empty.");
                return;
            }

            foreach (var item in cart)
            {
                Console.WriteLine(item);
            }
        }
    }
}