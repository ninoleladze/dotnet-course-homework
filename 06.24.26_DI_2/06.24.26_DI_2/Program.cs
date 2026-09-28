using System;

namespace _06._24._26_DI_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("======================================");
                Console.WriteLine("          C# OOP TASKS MENU           ");
                Console.WriteLine("======================================");
                Console.ResetColor();


                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  [1] Person");
                Console.WriteLine("  [2] Bank Account");
                Console.WriteLine("  [3] Product");
                Console.WriteLine("  [4] Temperature");
                Console.WriteLine("  [5] Rectangle");
                Console.WriteLine("  [6] Counter");
                Console.WriteLine("  [7] Clock");
                Console.WriteLine("  [8] Shopping Cart");
                Console.WriteLine("  [9] User");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  [0] Exit");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("======================================");
                Console.Write("Select a task (0-9): ");
                Console.ResetColor();

                try
                {
                    string input = Console.ReadLine();
                    int choice = int.Parse(input);

                    Console.Clear();

                    if (choice != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"--- Running Task {choice} ---\n");
                        Console.ResetColor();
                    }

                    switch (choice)
                    {
                        case 0:
                            running = false;
                            Console.WriteLine("Exiting... Goodbye!");
                            break;
                        case 1: TestPerson(); break;
                        case 2: TestBank(); break;
                        case 3: TestProduct(); break;
                        case 4: TestTemp(); break;
                        case 5: TestRectangle(); break;
                        case 6: TestCounter(); break;
                        case 7: TestClock(); break;
                        case 8: TestCart(); break;
                        case 9: TestUser(); break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Invalid choice. Enter 0-9.");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Please enter a number.");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"System Error: {ex.Message}");
                    Console.ResetColor();
                }

                if (running)
                {
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                }
            }
        }

       
        static void TestPerson()
        {
            Person p = new Person();
            p.Name = "John";
            p.Age = 150; 
            p.Age = 30;  

            Console.WriteLine($"Person -> Name: {p.Name}, Age: {p.Age}");
        }

        static void TestBank()
        {
            BankAccount acc = new BankAccount();
            acc.Deposit(5000);
            acc.Withdraw(1500);
            acc.Withdraw(10000);

            Console.WriteLine($"Balance: ${acc.Balance}");
        }

        static void TestProduct()
        {
            Product prod = new Product();
            prod.Name = "Keyboard";
            prod.Price = -50; 
            prod.Price = 120;
            prod.Description = "Mechanical keyboard";

            Console.WriteLine($"Product: {prod.Name} | Price: ${prod.Price} | Desc: {prod.Description}");
        }

        static void TestTemp()
        {
            Temperature temp = new Temperature();
            temp.Celsius = 22.5;

            Console.WriteLine($"Temp: {temp.Celsius}°C = {temp.Fahrenheit}°F");
        }

        static void TestRectangle()
        {
            Rectangle rect = new Rectangle();
            rect.Width = 15;
            rect.Height = 10;
            rect.Width = -5;

            Console.WriteLine($"Rectangle -> Area: {rect.Area}, Perimeter: {rect.Perimeter}");
        }

        static void TestCounter()
        {
            Counter counter = new Counter();
            counter.Increment();
            counter.Increment();
            counter.Decrement();
            counter.Decrement();
            counter.Decrement(); 

            Console.WriteLine($"Counter Value: {counter.Count}");
        }

        static void TestClock()
        {
            Clock clock = new Clock();
            clock.Hours = 25; 
            clock.Minutes = -5; 

            Console.WriteLine($"Time: {clock.ToString()}");
        }

        static void TestCart()
        {
            ShoppingCart cart = new ShoppingCart();
            cart.AddItem(45.99);
            cart.AddItem(12.50);
            cart.AddItem(-10);

            Console.WriteLine($"Cart -> Items: {cart.ItemCount}, Total: ${cart.Total}");
        }

        static void TestUser()
        {
            try
            {
                User user = new User("admin");
                user.SetPassword("123"); 
                user.SetPassword("SecurePass2026");

                Console.WriteLine("Check 'wrong_pass': " + user.CheckPassword("wrong_pass"));
                Console.WriteLine("Check 'SecurePass2026': " + user.CheckPassword("SecurePass2026"));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}