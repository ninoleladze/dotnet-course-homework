using _2._20._26.Data;
using _2._20._26.DTOs;
using _2._20._26.Models;

namespace _2._20._26.Services.Products
{
    public class ProductServices : IProductServices
    {
        private DataContext DC;
        public ProductServices(DataContext db) => DC = db;

        public string CreateProduct(CreateProductDto req)
        {
            if (string.IsNullOrWhiteSpace(req.Name))
                return "Product name is required.";
            if (string.IsNullOrWhiteSpace(req.Description))
                return "Product description is required.";
            if (req.Price <= 0)
                return "Product price must be greater than zero.";

            var product = new Product
            {
                Name = req.Name,
                Description = req.Description,
                Price = req.Price
            };

            DC.Products.Add(product);
            DC.SaveChanges();
            return "Product created successfully!";
        }

        public string DeleteProduct(int productId)
        {
            var product = DC.Products.Find(productId);
            if (product == null) return "Product not found.";

            DC.Products.Remove(product);
            DC.SaveChanges();

            return "Success";
        }


        public string EditProduct(int productId, UpdateProductDto req)
        {
            var product = DC.Products.Find(productId);
            if (product == null)
                return "Product not found.";

            if (!string.IsNullOrWhiteSpace(req.Name))
                product.Name = req.Name;

            if (!string.IsNullOrWhiteSpace(req.Description))

                product.Description = req.Description;

            if (req.Price.HasValue && req.Price.Value > 0)
                product.Price = req.Price.Value;

            DC.SaveChanges();

            return "Product updated successfully!";
        }

        public List<Product> GetProducts()
        {
            return DC.Products.ToList();
        }

    }

}
