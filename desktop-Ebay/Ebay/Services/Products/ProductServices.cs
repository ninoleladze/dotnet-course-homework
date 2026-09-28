using Ebay.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebay.Services.Products
{
    internal class ProductServices : IProductServices
    {
        private readonly DataContext dataContext = new DataContext();
        public void CreateProduct()
        {
            Console.WriteLine("Enter product name:");
            string name = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(name))throw new Exception("Product name cannot be empty");
            Console.WriteLine("Enter product description:");
            string description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(description)) throw new Exception("Product description cannot be empty");
            Console.WriteLine("Enter product category:");
            string category = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(category)) throw new Exception("Product category cannot be empty");
            Console.WriteLine("Enter product price:");
            string priceInput = Console.ReadLine();
            if (!decimal.TryParse(priceInput, out decimal price)) throw new Exception("Price must be a valid number!");
            if (price <= 0) throw new Exception("Price must be greater than zero!");
            Models.Product product = new Models.Product
            {
                Name = name,
                Description = description,
                Category = category,
                Price = price
            };
            dataContext.products.Add(product);
            dataContext.SaveChanges();
            Console.WriteLine("Product created successfully!");

        }

        public void DeleteProduct()
        {
            Console.WriteLine("Enter product id to delete");
            string idInput = Console.ReadLine();
            if (!int.TryParse(idInput, out int id)) throw new Exception("Id must be a valid number!");
            var product = dataContext.products.Find(id);
            if (product == null) throw new Exception("Product not found!");
            dataContext.products.Remove(product);
            dataContext.SaveChanges();
            Console.WriteLine("Product deleted successfully!");


        }

        public void EditProduct()
        {
            Console.WriteLine("Enter product id to edit");
            string idInput = Console.ReadLine();
            if (!int.TryParse(idInput, out int id)) throw new Exception("Id must be a valid number!");
            var product = dataContext.products.Find(id);
            if (product == null) throw new Exception("Product not found!");

            Console.WriteLine("Enter new product name (leave empty to keep current):");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                product.Name = name;
            }
            Console.WriteLine("Enter new product description (leave empty to keep current):");
            string description = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(description))
            {
                product.Description = description;
            }
            Console.WriteLine("Enter new product category (leave empty to keep current):");
            string category = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(category))
            {
                product.Category = category;
            }
            Console.WriteLine("Enter new product price (leave empty to keep current):");
            string priceInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(priceInput))
            {
                if (!decimal.TryParse(priceInput, out decimal price)) throw new Exception("Price must be a valid number!");
                if (price <= 0) throw new Exception("Price must be greater than zero!");
                product.Price = price;
            }
            dataContext.SaveChanges();
            Console.WriteLine("Product updated successfully!");



        }


        public void SearchProducts()
        {
            Console.WriteLine("Enter product name to search:");
            string keyword = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(keyword)) throw new Exception("Search keyword cannot be empty!");

            var products = dataContext.products
                .Where(p => p.Name.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!products.Any()) throw new Exception("No products found!");

            Console.WriteLine("Search Results:");
            foreach (var product in products)
            {
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Category: {product.Category}, Price: {product.Price:C}");
            }

        }

        public void ShowProducts()
        {
            var products = dataContext.products.ToList();
            if (!products.Any()) throw new Exception("No products available!");
            Console.WriteLine("Products List:");
            foreach (var product in products)
            {
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Category: {product.Category}, Price: {product.Price:C}");
            }


        }
    }
}
