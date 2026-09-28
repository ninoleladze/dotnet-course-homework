using ShoppingApp.Services.Products;

namespace ShoppingApp.Menus
{
    internal static class ProductMenu
    {
        private static readonly IProductServices _productServices = new ProductServices();

        public static void Show()
        {
            while (true)
            {
                Console.WriteLine("\n--- Product Menu ---");
                Console.WriteLine("1. Create Product");
                Console.WriteLine("2. Edit Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Show Products");
                Console.WriteLine("5. Search Products");
                Console.WriteLine("0. Back");

                string? choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1": _productServices.CreateProduct(); break;
                        case "2": _productServices.EditProduct(); break;
                        case "3": _productServices.DeleteProduct(); break;
                        case "4": _productServices.ShowProducts(); break;
                        case "5": _productServices.SearchProducts(); break;
                        case "0": return;
                        default: Console.WriteLine("Invalid choice!"); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}