using _06._10._26_DI2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06._10._26_DI2.Services
{
    internal class CarService
    {
        public void ShowAllCars(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                cars[i].DisplayCar();
            }
        }

        public void ShowNewCars(List<Car> cars)
        {
            List<Car> newCars = cars.Where(c => c.IsNew == true).ToList();
            ShowAllCars(newCars);
        }

        public void ShowCarsSortedByPrice(List<Car> cars)
        {
            List<Car> sorted = cars.OrderBy(c => c.Price).ToList();
            ShowAllCars(sorted);
        }

        public void SearchByBrand(List<Car> cars)
        {
            Console.Write("Enter brand: ");
            string brand = Console.ReadLine();
            List<Car> filtered = cars.Where(c => c.Brand.ToLower() == brand.ToLower()).ToList();
            if (filtered.Count == 0)
            {
                Console.WriteLine("No cars found for this brand.");
                return;
            }
            ShowAllCars(filtered);
        }

        public void ShowFastCars(List<Car> cars)
        {
            List<Car> fast = cars.Where(c => c.MaxSpeedKmh > 200).ToList();
            ShowAllCars(fast);
        }
    }
}
