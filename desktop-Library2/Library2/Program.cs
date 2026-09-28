using Library2;

LibraryService lib = new LibraryService();

while (true)
{
    Console.WriteLine("Library");
    Console.WriteLine("1. add new book");
    Console.WriteLine("2. borrow book");
    Console.WriteLine("3. return book");
    Console.WriteLine("4. list available");
    Console.WriteLine("5. get user borrowed books");

    Console.WriteLine("eneter key :");

    string key= Console.ReadLine();

    if (key == "1")
    {
        Console.Clear();
        try
        {
            Console.WriteLine("enter title:");
            string title = Console.ReadLine();
            Console.WriteLine("enter author");
            string author = Console.ReadLine();
            Console.WriteLine("enter year:");
            int year = int.Parse(Console.ReadLine());

            lib.AddBook(title, author, year);
        }
        catch (Exception e){
            Console.WriteLine(e.Message);
        }

    }
    else if (key == "2")
    {
        Console.Clear();
        try
        {
            lib.ListAvailableBooks();
            Console.WriteLine("");
            Console.WriteLine("enter bookid:");
            int bookID = int.Parse(Console.ReadLine());
            lib.BorrowBook(bookID);
        }
        catch(Exception e) {
            Console.WriteLine(e.Message);
        }

    }
    else if (key == "3")
    {
         Console.Clear() ;
        try
        {
            lib.GetUserBorrowedBooks();
            Console.WriteLine("");
            Console.WriteLine("enter bookid:");
            int bookID = int.Parse(Console.ReadLine());
            lib.ReturnBook(bookID);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    else if (key == "4")
    {Console.Clear();
        try
        {
            lib.ListAvailableBooks();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    else if (key == "5")
    {
        Console.Clear();
        try { lib.GetUserBorrowedBooks(); }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }



}


