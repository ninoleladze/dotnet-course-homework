using Amazon.Data;
using Amazon.Models;
using System;
using System.Linq;

namespace Amazon.Services.Products
{
    internal class ProductServices : IProductServices
    {
        private readonly DataContext _db = new DataContext();

        ////// Admin functions
        public void CreateProduct()
        {
            Console.WriteLine("Enter product name:");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name is required!");

            Console.WriteLine("Enter product description:");
            string description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(description)) throw new Exception("Description is required!");

            Console.WriteLine("Enter product category:");
            string category = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(category)) throw new Exception("Category is required!");

            Console.WriteLine("Enter product price:");
            string priceInput = Console.ReadLine();
            if (!decimal.TryParse(priceInput, out decimal price)) throw new Exception("Price must be a valid number!");
            if (price <= 0) throw new Exception("Price must be greater than zero!");

            var product = new Product
            {
                Name = name.Trim(),
                Description = description.Trim(),
                Category = category.Trim(),
                Price = price
            };

            _db.Products.Add(product);
            _db.SaveChanges();

            Console.WriteLine("Product created successfully!");
        }

        public void DeleteProduct()
        {
            Console.WriteLine("Enter product Id to delete:");
            string idInput = Console.ReadLine();
            if (!int.TryParse(idInput, out int id)) throw new Exception("Invalid Id format!");

            var product = _db.Products.Find(id);
            if (product == null) throw new Exception("Product not found!");

            _db.Products.Remove(product);
            _db.SaveChanges();
            Console.WriteLine("Product deleted successfully!");
        }

        public void EditProduct()
        {
            Console.WriteLine("Enter product Id to edit:");
            string idInput = Console.ReadLine();
            if (!int.TryParse(idInput, out int id)) throw new Exception("Invalid Id format!");

            var product = _db.Products.Find(id);
            if (product == null) throw new Exception("Product not found!");

            Console.WriteLine("Enter new name (leave empty to keep current):");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) product.Name = name.Trim();

            Console.WriteLine("Enter new description (leave empty to keep current):");
            string description = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(description)) product.Description = description.Trim();

            Console.WriteLine("Enter new category (leave empty to keep current):");
            string category = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(category)) product.Category = category.Trim();

            Console.WriteLine("Enter new price (leave empty to keep current):");
            string priceInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(priceInput))
            {
                if (!decimal.TryParse(priceInput, out decimal newPrice)) throw new Exception("Price must be a valid number!");
                if (newPrice <= 0) throw new Exception("Price must be greater than zero!");
                product.Price = newPrice;
            }

            _db.SaveChanges();
            Console.WriteLine("Product updated successfully!");
        }

        ///////// User functions
        public void ShowProducts()
        {
            var products = _db.Products.ToList();
            if (!products.Any()) throw new Exception("No products available!");

            Console.WriteLine("Available Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Category: {product.Category}, Price: {product.Price:C}");
            }
        }

        public void SearchProducts()
        {
            Console.WriteLine("Enter product name to search:");
            string keyword = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(keyword)) throw new Exception("Search keyword cannot be empty!");

            var products = _db.Products
                .Where(p => p.Name.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!products.Any()) throw new Exception("No products found!");

            Console.WriteLine("Search Results:");
            foreach (var product in products)
            {
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Category: {product.Category}, Price: {product.Price:C}");
            }
        }
    }
}