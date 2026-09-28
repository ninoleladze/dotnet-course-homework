using ShoppingApp.Data;
using ShoppingApp.Models;
using System;
using System.Linq;

namespace ShoppingApp.Services.Products
{
    public class ProductServices : IProductServices
    {
        private readonly DataContext _db;

        public ProductServices()
        {
            _db = new DataContext();
        }

        public ProductServices(DataContext db)
        {
            _db = db;
        }

        public void CreateProduct()
        {
            Console.WriteLine("Enter product name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter category:");
            string category = Console.ReadLine();
            Console.WriteLine("Enter price:");
            string priceInput = Console.ReadLine();
            Console.WriteLine("Enter stock:");
            string stockInput = Console.ReadLine();

            if (!decimal.TryParse(priceInput, out decimal price) || price <= 0)
                throw new Exception("Price must be a positive number!");

            if (!int.TryParse(stockInput, out int stock) || stock < 0)
                throw new Exception("Stock must be a non-negative integer!");

            CreateProduct(name, description, category, price, stock);
            Console.WriteLine("Product created successfully!");
        }

        public Models.Product CreateProduct(string name, string description, string category, decimal price, int stock)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name is required!");
            if (string.IsNullOrWhiteSpace(description)) throw new Exception("Description is required!");
            if (string.IsNullOrWhiteSpace(category)) throw new Exception("Category is required!");
            if (price <= 0) throw new Exception("Price must be a positive number!");
            if (stock < 0) throw new Exception("Stock must be a non-negative integer!");

            var product = new Models.Product
            {
                Name = name.Trim(),
                Description = description.Trim(),
                Category = category.Trim(),
                Price = price,
                Stock = stock
            };

            _db.Products.Add(product);
            _db.SaveChanges();
            return product;
        }

        public void EditProduct()
        {
            Console.WriteLine("Enter product Id:");
            if (!int.TryParse(Console.ReadLine(), out int id)) throw new Exception("Invalid Id!");

            var product = _db.Products.Find(id) ?? throw new Exception("Product not found!");

            Console.WriteLine("Enter new name (leave empty to keep current):");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) product.Name = name.Trim();

            Console.WriteLine("Enter new price (leave empty to keep current):");
            string priceInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(priceInput))
            {
                if (!decimal.TryParse(priceInput, out decimal newPrice) || newPrice <= 0)
                    throw new Exception("Price must be positive!");
                product.Price = newPrice;
            }

            _db.SaveChanges();
            Console.WriteLine("Product updated successfully!");
        }

        public void DeleteProduct()
        {
            Console.WriteLine("Enter product Id:");
            if (!int.TryParse(Console.ReadLine(), out int id)) throw new Exception("Invalid Id!");

            var product = _db.Products.Find(id) ?? throw new Exception("Product not found!");
            _db.Products.Remove(product);
            _db.SaveChanges();
            Console.WriteLine("Product deleted successfully!");
        }

        public void ShowProducts()
        {
            var products = _db.Products.ToList();
            if (!products.Any())throw new Exception("No products available!");

            foreach (var p in products)
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Price: {p.Price:C}, Stock: {p.Stock}");
        }

        public void SearchProducts()
        {
            Console.WriteLine("Enter keyword:");
            string keyword = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(keyword)) throw new Exception("Keyword required!");

            var products = _db.Products.Where(p => p.Name.Contains(keyword)).ToList();
            if (!products.Any()) throw new Exception("No products found!");

            foreach (var p in products)
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Price: {p.Price:C}");
        }
    }
}