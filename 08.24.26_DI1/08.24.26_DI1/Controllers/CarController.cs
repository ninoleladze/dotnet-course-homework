using _08._24._26_DI1.Models;
using Microsoft.AspNetCore.Mvc;

namespace _08._24._26_DI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        List<Car> Cars = new List<Car>
        {
            new Car() { Brand = "Toyota", Model = "Corolla", Year = 2020 },
            new Car() { Brand = "BMW", Model = "X5", Year = 2021 },
            new Car() { Brand = "Ford", Model = "Focus", Year = 2019 }
        };

        [HttpGet]
        public List<Car> GetAllCars()
        {
            return Cars;
        }

        [HttpGet("byIndex/{index}")]
        public Car GetCarByIndex(int index)
        {
            return Cars[index];
        }

        [HttpGet("byBrand/{brand}")]
        public List<Car> GetCarsByBrand(string brand)
        {
            return Cars.Where(c => c.Brand == brand).ToList();
        }

        [HttpGet("latest")]
        public Car GetLatestCar()
        {
            return Cars.OrderByDescending(c => c.Year).First();
        }

        [HttpGet("count")]
        public int GetCarCount()
        {
            return Cars.Count;
        }
    }
}
