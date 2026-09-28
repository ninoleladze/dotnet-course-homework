using FileStream_APP;

Library library = new Library();

library.LoadBooks();

while (true)
{
    Console.WriteLine("========= Library =========");
    Console.WriteLine("1. create new book");
    Console.WriteLine("2. show all books");
    Console.WriteLine("3. delete book");

    Console.Write("Enter key: ");
    string key = Console.ReadLine();

    if (key == "1")
    {
        Console.Clear();
        library.CreateBook();
    }
    else if (key == "2")
    {
        Console.Clear();
        library.ShowBooks();
    }
    else if (key == "3")
    {
        Console.Clear();
        library.DeleteBook();
    }
    else break;
}