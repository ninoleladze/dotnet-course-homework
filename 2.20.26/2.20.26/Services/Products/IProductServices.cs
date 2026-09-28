using _2._20._26.DTOs;
using _2._20._26.Models;
using Microsoft.Extensions.Hosting;

namespace _2._20._26.Services.Products
{
    public interface IProductServices
    {

        string CreateProduct(CreateProductDto req);
        string DeleteProduct(int productId);
        string EditProduct(int productId, UpdateProductDto req);
        List<Product> GetProducts();


    }
}
