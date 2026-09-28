using _1028;

LibraryService library = new LibraryService();

,
while (true)
{

    Console.WriteLine("library:");
    Console.WriteLine("1. show borrowed books");
    Console.WriteLine("2. show available books");
    Console.WriteLine("3. borrow book");
    Console.WriteLine("4. return book");
    Console.WriteLine("5. add book");
    Console.WriteLine("6. remove book");
    Console.WriteLine("7. update book");
    Console.WriteLine("8. search book by title");
    Console.WriteLine("9. search book by author");
    Console.WriteLine("10. filter books by year");
    Console.WriteLine("11. get book by id");

    Console.WriteLine("enter your choice (1-11): ");
    int choice = int.Parse(Console.ReadLine());

    try
    {
        
        if (choice == 0)
        { 
            break;
        }
        else if (choice == 1)
        {
            Console.Clear();
            library.showBorrowedBooks();
        }
        else if (choice == 2)
        {
            Console.Clear();
            library.showAvailableBooks();
        }
        else if (choice == 3)
        {   
            Console.Clear();
            library.borrowBook();
        }
        else if (choice == 4)
        {
            Console.Clear();
            library.returnBook();
        }
        else if (choice == 5)
        {
            Console.Clear();
            library.addBook();
        }
        else if (choice == 6)
        {
            Console.Clear();
            library.removeBook();
        }
        else if (choice == 7)
        {
            Console.Clear();
            library.updateBook();
        }
        else if (choice == 8)
        {
            Console.Clear();
            library.SearchBookByTitle();
        }
        else if (choice == 9)
        {
            Console.Clear();
            library.searchBookByAuthor();
        }
        else if (choice == 10)
        {
            Console.Clear();
            library.filterBooksByYear();
        }
        else if (choice == 11)
        {
            Console.Clear();
            library.GetBookById();
        }
        else
        {
            break;
        }

    }

    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }


}