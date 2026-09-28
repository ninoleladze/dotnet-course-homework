using _08._24._26_DI1.Models;
using Microsoft.AspNetCore.Mvc;

namespace _08._24._26_DI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        List<Order> Orders = new List<Order>
        {
            new Order() { Customer = "Alice", Total = 250 },
            new Order() { Customer = "Bob", Total = 400 },
            new Order() { Customer = "Charlie", Total = 150 }
        };

        [HttpGet]
        public List<Order> GetAllOrders()
        {
            return Orders;
        }

        [HttpGet("byIndex/{index}")]
        public Order GetOrderByIndex(int index)
        {
            return Orders[index];
        }

        [HttpGet("byCustomer/{customer}")]
        public List<Order> GetOrdersByCustomer(string customer)
        {
            return Orders.Where(o => o.Customer == customer).ToList();
        }

        [HttpGet("largest")]
        public Order GetLargestOrder()
        {
            return Orders.OrderByDescending(o => o.Total).First();
        }

        [HttpGet("count")]
        public int GetOrderCount()
        {
            return Orders.Count;
        }
    }
}
