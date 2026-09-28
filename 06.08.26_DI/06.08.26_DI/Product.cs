using System;
using System.Collections.Generic;
using System.Text;

namespace _06._08._26_DI
{
    internal class Product
    {
        public string name;
        public double price;
    }

    internal class ProductStore
    {
        public List<Product> products = new List<Product>();

        public void AddProduct(Product p)
        {
            products.Add(p);
        }

        public int CountExpensive()
        {
            return products.Where(p => p.price > 100).Count();
        }

        public Product GetCheapest()
        {
            return products.OrderBy(p => p.price).First();
        }

        public bool HasProduct(string name)
        {
            return products.Any(p => p.name == name);
        }
    }
}
