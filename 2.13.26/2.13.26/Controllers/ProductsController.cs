using _2._13._26.Data;
using _2._13._26.DTOs;
using _2._13._26.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2._13._26.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private DataContext DC;
        public ProductsController(DataContext db) => DC = db;



        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = DC.Products.ToList();


            return Ok(products);

        }


        [HttpGet("{productId}")]
        public IActionResult GetProduct(int productId)
        {
            var product = DC.Products.Find(productId);
            if (product == null)
                return NotFound($"Product with id {productId} not found.");
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto req)
        {
            Product product = new Product
            {
                Name = req.Name,
                Description = req.Description,
                Price = req.Price,
                Stock = req.Stock,
                Category = req.Category
            };

            DC.Products.Add(product);
            DC.SaveChanges();
            return Ok("Success!");
        }

    }
}
