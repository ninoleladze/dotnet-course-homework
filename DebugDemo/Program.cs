using Newtonsoft.Json;

public class Product
{

    public string Name { get; set; }
    public double Price { get; set; }
    public List<string> Tags { get; set; }
}

public class Program
{
    public static void Main()
    {
    //     string json = "{\"name\": \"Laptop\", \"price\": 999.99, \"tags\": [\"electronics\", \"computer\"]}";
    //     Product prod =  JsonConvert.DeserializeObject<Product>(json);
    //     Console.WriteLine($"Name: {prod.Name}");
    //     Console.WriteLine($"Price: {prod.Price}");
    //     Console.WriteLine("Tags: " + string.Join(", ", prod.Tags));

        Product newProd = new Product
        {
            Name = "Smartphone",
            Price = 499.99,
            Tags = new List<string> { "electronics", "mobile" }
        };

        string json = JsonConvert.SerializeObject(newProd, Formatting.Indented);
        Console.WriteLine(json);
        



    }
}