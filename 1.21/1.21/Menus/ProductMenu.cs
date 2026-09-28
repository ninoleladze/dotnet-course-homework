using _1._21.Services;
using System;

namespace _1._21.Menus
{
    internal class ProductMenu
    {
        private ProductServices productServices = new ProductServices();

        public void ShowProductMenu()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("=== Product Menu ===");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("1. Add Product");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("2. View All Products");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("3. Update Product");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("4. Delete Product");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("5. Search Products");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("6. Exit");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nSelect an option: ");
                    Console.ResetColor();

                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a number.");
                        Console.ResetColor();
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            productServices.CreateProduct();
                            break;
                        case 2:
                            productServices.GetAllProducts();
                            break;
                        case 3:
                            productServices.UpdateProduct();
                            break;
                        case 4:
                            productServices.DeleteProduct();
                            break;
                        case 5:
                            productServices.SearchProducts();
                            break;
                        case 6:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Returning to main menu...");
                            Console.ResetColor();
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid option. Please try again.");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }
    }
}