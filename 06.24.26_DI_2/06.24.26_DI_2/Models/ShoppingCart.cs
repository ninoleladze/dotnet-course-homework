using System;
using System.Collections.Generic;
using System.Linq;

public class ShoppingCart
{
    private List<double> prices;

    public ShoppingCart()
    {
        prices = new List<double>();
    }

    public void AddItem(double price)
    {
        if (price > 0)
            prices.Add(price);
        else
            Console.WriteLine("Error: Price must be a positive number.");
    }

    public double Total
    {
        get { return prices.Sum(); }
    }

    public int ItemCount
    {
        get { return prices.Count; }
    }
}