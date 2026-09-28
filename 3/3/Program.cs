using System.Collections.Generic;
using System.Linq;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}

public class CartItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice => Product.Price * Quantity;
}


public class ShoppingCart
{
    private List<CartItem> _items;

    public ShoppingCart()
    {
        _items = new List<CartItem>();
    }

    public void AddItem(Product product, int quantity)
    {
        var existingItem = _items.FirstOrDefault(item => item.Product.Id == product.Id);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            _items.Add(new CartItem { Product = product, Quantity = quantity });
        }
    }

    public void RemoveItem(int productId)
    {
        _items.RemoveAll(item => item.Product.Id == productId);
    }

    public void UpdateQuantity(int productId, int newQuantity)
    {
        var existingItem = _items.FirstOrDefault(item => item.Product.Id == productId);
        if (existingItem != null)
        {
            existingItem.Quantity = newQuantity;
            if (existingItem.Quantity <= 0)
            {
                RemoveItem(productId);
            }
        }
    }

    public List<CartItem> GetItems()
    {
        return _items;
    }

    public decimal GetTotal()
    {
        return _items.Sum(item => item.TotalPrice);
    }

    public void ClearCart()
    {
        _items.Clear();
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        // Create some products
        Product laptop = new Product { Id = 1, Name = "Laptop", Price = 1200.00m, StockQuantity = 10 };
        Product mouse = new Product { Id = 2, Name = "Mouse", Price = 25.00m, StockQuantity = 50 };

        // Create a shopping cart
        ShoppingCart myCart = new ShoppingCart();

        // Add items to the cart
        myCart.AddItem(laptop, 1);
        myCart.AddItem(mouse, 2);

        // Update quantity
        myCart.UpdateQuantity(mouse.Id, 3);

        // Remove an item
        // myCart.RemoveItem(laptop.Id);

        // Display cart contents and total
        foreach (var item in myCart.GetItems())
        {
            Console.WriteLine($"Item: {item.Product.Name}, Quantity: {item.Quantity}, Price: {item.TotalPrice:C}");
        }
        Console.WriteLine($"Total: {myCart.GetTotal():C}");

        // Clear the cart
        myCart.ClearCart();
        Console.WriteLine($"Cart cleared. Total items: {myCart.GetItems().Count}");
    }
}