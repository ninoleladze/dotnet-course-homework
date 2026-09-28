using ShoppingApp.Data;
using ShoppingApp.Enums;
using ShoppingApp.Models;
using ShoppingApp.Services.Users;
using System;
using System.Linq;

namespace ShoppingApp.Services.Orders
{
    public class OrderServices : IOrderServices
    {
        private readonly DataContext _db;

        public OrderServices()
        {
            _db = new DataContext();
        }

        public OrderServices(DataContext db)
        {
            _db = db;
        }

        public void AddToCart()
        {
            if (UserServices.LoggedInUser == null) throw new Exception("Login required!");

            Console.WriteLine("Enter product Id:");
            if (!int.TryParse(Console.ReadLine(), out int productId)) throw new Exception("Invalid Id!");

            AddToCart(productId);
        }

        public void AddToCart(int productId)
        {
            if (UserServices.LoggedInUser == null) throw new Exception("Login required!");

            var product = _db.Products.Find(productId) ?? throw new Exception("Product not found!");
            if (product.Stock <= 0) throw new Exception("Product out of stock!");

            var cart = _db.Carts.FirstOrDefault(c => c.UserId == UserServices.LoggedInUser.Id);
            if (cart == null)
            {
                cart = new Cart { UserId = UserServices.LoggedInUser.Id };
                _db.Carts.Add(cart);
            }

            cart.Products.Add(product);
            _db.SaveChanges();
        }

        public void Checkout()
        {
            if (UserServices.LoggedInUser == null) throw new Exception("Login required!");

            CheckoutForCurrentUser();
            Console.WriteLine("Order placed successfully!");
        }

        public void CheckoutForCurrentUser()
        {
            if (UserServices.LoggedInUser == null) throw new Exception("Login required!");

            var cart = _db.Carts.FirstOrDefault(c => c.UserId == UserServices.LoggedInUser.Id)
                       ?? throw new Exception("Cart is empty!");

            if (!cart.Products.Any()) throw new Exception("No products in cart!");

            var productGroups = cart.Products.GroupBy(p => p.Id)
                .Select(g => new { ProductId = g.Key, Quantity = g.Count() })
                .ToList();

            foreach (var pg in productGroups)
            {
                var prod = _db.Products.Find(pg.ProductId) ?? throw new Exception("Product not found during checkout!");
                if (prod.Stock < pg.Quantity) throw new Exception($"Insufficient stock for product '{prod.Name}' (requested: {pg.Quantity}, available: {prod.Stock})");
                prod.Stock -= pg.Quantity;
            }

            var currentCart = _db.Carts.First(c => c.UserId == UserServices.LoggedInUser.Id);

            var order = new Order
            {
                UserId = currentCart.UserId,
                Products = currentCart.Products.ToList(),
                TotalAmount = currentCart.Products.Sum(p => p.Price),
                Status = OrderStatus.Paid
            };

            _db.Orders.Add(order);
            currentCart.Products.Clear();
            _db.SaveChanges();
        }

        public void ViewOrders()
        {
            if (UserServices.LoggedInUser == null) throw new Exception("Login required!");

            var orders = _db.Orders.Where(o => o.UserId == UserServices.LoggedInUser.Id).ToList();
            if (!orders.Any()) throw new Exception("No orders found!");

            foreach (var o in orders)
                Console.WriteLine($"Order {o.Id}, Total: {o.TotalAmount:C}, Status: {o.Status}");
        }
    }
}