using _2._20._26.DTOs;
using _2._20._26.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2._20._26.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = _productServices.GetProducts();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto req)
        {
            var result = _productServices.CreateProduct(req);
            return Ok(result);
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            var result = _productServices.DeleteProduct(productId);
            return Ok(result);
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(int productId, UpdateProductDto req)
        {
            var result = _productServices.EditProduct(productId, req);
            return Ok(result);
        }
    }



}

