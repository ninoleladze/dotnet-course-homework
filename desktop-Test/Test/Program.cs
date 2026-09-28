using Test.Menus;
using System;

        while (true)
        {
            try
            {
                Console.WriteLine("=== Main Menu ===");
                Console.WriteLine("1. School Admin Menu");
                Console.WriteLine("2. Student Menu");
                Console.WriteLine("3. Exit");
                Console.Write("Enter choice: ");
                string key = Console.ReadLine();

                switch (key)
                {
                    case "1":
                        Console.Clear();
                        SchoolAdminMenu.Start();
                        break;
                    case "2":
                        Console.Clear();
                        StudentMenu.Start();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
  