using _1._21.Data;
using _1._21.Enums;
using _1._21.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._21.Services
{
    internal class ProductServices
    {
        private DataContext DC = new DataContext();

        public void CreateProduct() {
            CheckAdmin();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Enter product name:");
            string name = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(name))throw new Exception("Product name cannot be empty.");
            Console.WriteLine("Enter stock quantity:");
            int stockQuantity = int.Parse(Console.ReadLine());
            if(stockQuantity<0 || stockQuantity >1000)throw new Exception("Stock quantity cannot be greater then 1 and lower then 1000");
            Console.WriteLine("Enter price:");
            decimal price = decimal.Parse(Console.ReadLine());
            if(price<0 || price >10000)throw new Exception("Price cannot be greater then 1 and lower then 10000");
            Console.WriteLine("Enter category:");
            string category = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(category))throw new Exception("Category cannot be empty.");
            Console.WriteLine("Enter description:");
            string description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(description)) throw new Exception("Description cannot be empty.");
            var product = new Product
            {
                Name = name,
                StockQuantity = stockQuantity,
                Price = price,
                Category = category,
                Description = description
            };
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            DC.Products.Add(product);
            Console.WriteLine("Product created successfully.");
            Console.ResetColor();


        }
        public void DeleteProduct() {
            CheckAdmin();
            GetAllProducts();
            Console.WriteLine("Enter the ID of the product to delete:");
            int productId = int.Parse(Console.ReadLine());
            var product =DC.Products.Find(productId);
            if(product == null)throw new Exception("Product not found.");
            DC.Products.Remove(product);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Product deleted successfully.");
            Console.ResetColor();


        }
        public void UpdateProduct() {
            CheckAdmin();
            GetAllProducts();
            Console.WriteLine("Enter the ID of the product to update:");
            int productId = int.Parse(Console.ReadLine());
            var product = DC.Products.Find(productId);
            if (product == null) throw new Exception("Product not found.");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Enter new product name (leave blank to keep current):");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) product.Name = name;
            Console.WriteLine("Enter new stock quantity (leave blank to keep current):");
            string stockQuantityInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(stockQuantityInput))
            {
                int stockQuantity = int.Parse(stockQuantityInput);
                if (stockQuantity < 0 || stockQuantity > 1000) throw new Exception("Stock quantity cannot be greater then 1 and lower then 1000");
                product.StockQuantity = stockQuantity;
            }
            Console.WriteLine("Enter new price (leave blank to keep current):");
            string priceInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(priceInput))
            {
                decimal price = decimal.Parse(priceInput);
                if (price < 0 || price > 10000) throw new Exception("Price cannot be greater then 1 and lower then 10000");
                product.Price = price;
            }
            Console.WriteLine("Enter new category (leave blank to keep current):");
            string category = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(category)) product.Category = category;
            Console.WriteLine("Enter new description (leave blank to keep current):");
            string description = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(description)) product.Description = description;
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Product updated successfully.");
            Console.ResetColor();

        }
        

        
        public void GetAllProducts() {
            CheckLoggedIn();
            var products = DC.Products.ToList();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Products:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.ResetColor();
        }
        public void SearchProducts()
        {
            CheckLoggedIn();
            Console.WriteLine("Enter product name to search:");
            string search = Console.ReadLine().ToLower();
            var products = DC.Products.Where(p => p.Name.ToLower().Contains(search)||
            p.Description.ToLower().Contains(search)||
            p.Category.ToLower().Contains(search))
            .ToList();




        }

        public void CheckAdmin()
        {
           if(UserServices.loggedInUser==null)throw new Exception("You must be logged in to perform this action.");
           if(UserServices.loggedInUser.Role != UserRoles.Admin)throw new Exception("You must be an admin to perform this action.");
        }
        public void CheckLoggedIn()
        {
            if (UserServices.loggedInUser == null) throw new Exception("You must be logged in to perform this action.");
        }

    }
}
