using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data;
using ShoppingApp.Models;
using ShoppingApp.Services.Products;
using ShoppingApp.Services.Users;
using ShoppingApp.Services.Orders;
using Xunit;
using System.Linq;

namespace ShoppingApp.Tests
{
    public class UserProductOrderTests
    {
        private DataContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;
            return new DataContext(options);
        }

        [Fact]
        public void Register_CreateProduct_AddToCart_Checkout_Flow()
        {
            var db = CreateInMemoryContext();

            var userService = new UserServices(db);
            var productService = new ProductServices(db);
            var orderService = new OrderServices(db);

            // Register user
            userService.Register("testuser", "test@example.com", "password123");
            var user = db.Users.FirstOrDefault(u => u.Username == "testuser");
            Assert.NotNull(user);

            // Create product
            var product = productService.CreateProduct("Laptop", "Fast laptop", "Electronics", 999.99m, 2);
            Assert.NotNull(product);
            Assert.Equal(2, product.Stock);

            // Login
            userService.Login("testuser", "password123");

            // Add to cart twice (simulate two quantities)
            orderService.AddToCart(product.Id);
            orderService.AddToCart(product.Id);

            // Checkout
            orderService.Checkout();

            // Verify order created and stock decremented
            var order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.UserId == user!.Id);
            Assert.NotNull(order);
            Assert.Equal(999.99m * 2, order!.TotalAmount);
            var prodAfter = db.Products.Find(product.Id);
            Assert.NotNull(prodAfter);
            Assert.Equal(0, prodAfter!.Stock);
        }
    }
}
