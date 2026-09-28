using _06._10._26_DI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06._10._26_DI.Services
{
    internal class ProductService
    {
        public void ShowAllProducts(List<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {

                products[i].DisplayProduct();

            }
        }

        public void ViewProductsSortedByPrice(List<Product> products)
        {
            List<Product> sortedProducts = products.OrderBy(p => p.Price).ToList();
            ShowAllProducts(sortedProducts);
        }

        public void ViewProductsSortedByPriceDescending(List<Product> products)
        {
            List<Product> sortedProducts = products.OrderByDescending(p => p.Price).ToList();
            ShowAllProducts(sortedProducts);
        }

        public void ShowNewProducts(List<Product> products)
        {
            List<Product> newProducts = products.Where(p => p.IsNew == true).ToList();
            ShowAllProducts(newProducts);
        }

}
}
