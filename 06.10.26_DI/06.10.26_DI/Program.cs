using _06._10._26_DI.Helpers;
using _06._10._26_DI.Models;
using _06._10._26_DI.Services;

List<Product> products = new List<Product>()
{
    new Product { Name = "Laptop",        IsNew = true,  Price = 2500, Stock = 15 },
    new Product { Name = "Mouse",         IsNew = false, Price = 45,   Stock = 120 },
    new Product { Name = "Keyboard",      IsNew = true,  Price = 110,  Stock = 80 },
    new Product { Name = "Monitor",       IsNew = false, Price = 600,  Stock = 25 },
    new Product { Name = "Headphones",    IsNew = true,  Price = 220,  Stock = 60 },
    new Product { Name = "Webcam",        IsNew = false, Price = 90,   Stock = 40 },
    new Product { Name = "USB Hub",       IsNew = true,  Price = 35,   Stock = 200 },
    new Product { Name = "SSD 1TB",       IsNew = true,  Price = 180,  Stock = 55 },
    new Product { Name = "Power Bank",    IsNew = false, Price = 70,   Stock = 95 },
    new Product { Name = "Smartwatch",    IsNew = true,  Price = 450,  Stock = 10 },
    new Product { Name = "Router",        IsNew = false, Price = 130,  Stock = 35 },
    new Product { Name = "Microphone",    IsNew = true,  Price = 160,  Stock = 0 },
};

bool IS_APP_RUNNING = true;
MenuHelper menuHelper = new MenuHelper();
ProductService productService = new ProductService();

while (IS_APP_RUNNING)
{
    menuHelper.ShowMenu();
    string archevani = menuHelper.AskUser();
    if(archevani == "1")
    {
        Console.Clear();
        productService.ShowAllProducts(products);
        menuHelper.Wait();


    }
    else if (archevani == "2")
    {
        Console.Clear();
        productService.ViewProductsSortedByPrice(products);
        menuHelper.Wait();

    }
    else if (archevani == "3")
    {
        Console.Clear();
        productService.ViewProductsSortedByPriceDescending(products);
        menuHelper.Wait();
    }
    else if (archevani == "4")
    {
        Console.Clear();
        productService.ShowNewProducts(products);
        menuHelper.Wait();
    }
    else if (archevani == "0")
    {
        Console.Clear();
        IS_APP_RUNNING = false;
    }
}