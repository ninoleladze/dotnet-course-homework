using LibraryApp1.Services.Book;
using System;

namespace LibraryApp1.Menus
{
    internal class BookMenu
    {
        BookService _bookService = new BookService();

        public void Show()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
                Console.WriteLine("Book Menu:");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. Update Book");
                Console.WriteLine("4. List Books");
                Console.WriteLine("5. Search Books");
                Console.WriteLine("6. Back to Main Menu");
                Console.ResetColor();

                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            _bookService.CreateBook();
                            break;
                        case "2":
                            _bookService.DeleteBook();
                            break;
                        case "3":
                            _bookService.UpdateBook();
                            break;
                        case "4":
                            _bookService.GetAllBooks();
                            break;
                        case "5":
                            _bookService.SearchBooks();
                            break;
                        case "6":
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
