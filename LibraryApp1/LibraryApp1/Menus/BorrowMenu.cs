using LibraryApp1.Services.Borrow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp1.Menus
{
    internal class BorrowMenu
    {
        BorrowService borrowService = new BorrowService();
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Borrow Menu:");
            Console.WriteLine("1. Borrow Book");
            Console.WriteLine("2. Return Book");
            Console.WriteLine("3. List Borrowed Books");
            Console.WriteLine("4. List Overdue Books");
            Console.WriteLine("5. Return Overdue Book");
            Console.WriteLine("6. Lost Book");
            Console.WriteLine("0. Back to Main Menu");
            Console.ResetColor();
            Console.WriteLine("Select an option:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    borrowService.BorrowBook();
                    break;
                case "2":
                    borrowService.ReturnBook();
                    break;
                case "3":
                    borrowService.ListBorrowedBooks();
                    break;
                case "4":
                    borrowService.ListOverdueBooks();
                    break;
                case "5":
                    borrowService.ReturnOverdueBook();
                    break;
                case "6":
                    borrowService.LostBook();
                    break;
                case "0":
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
