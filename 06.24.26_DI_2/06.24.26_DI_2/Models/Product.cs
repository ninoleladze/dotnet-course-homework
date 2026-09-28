using System;

public class Product
{
    private string name;
    private decimal price;

    public string Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                name = value;
            else
                Console.WriteLine("Error: Product name cannot be empty.");
        }
    }

    public decimal Price
    {
        get { return price; }
        set
        {
            if (value >= 0)
                price = value;
            else
                Console.WriteLine("Error: Price cannot be negative.");
        }
    }

    public string Description { get; set; }
}