using _08._24._26_DI1.Models;
using Microsoft.AspNetCore.Mvc;

namespace _08._24._26_DI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        List<Product> Products = new List<Product>
        {
            new Product() { Title = "Laptop", Price = 1200 },
            new Product() { Title = "Phone", Price = 800 },
            new Product() { Title = "Tablet", Price = 500 }
        };

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return Products;
        }

        [HttpGet("byIndex/{index}")]
        public Product GetProductByIndex(int index)
        {
            return Products[index];
        }

        [HttpGet("byTitle/{title}")]
        public List<Product> GetProductsByTitle(string title)
        {
            return Products.Where(p => p.Title == title).ToList();
        }

        [HttpGet("mostExpensive")]
        public Product GetMostExpensiveProduct()
        {
            return Products.OrderByDescending(p => p.Price).First();
        }

        [HttpGet("count")]
        public int GetProductCount()
        {
            return Products.Count;
        }
    }
}
