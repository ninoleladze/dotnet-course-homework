using System;
using System.Collections.Generic;
using BooksApp.Models;
using BooksApp.Repositories;

Console.WriteLine("Starting book repository demo...");

var initialBooks = new List<Book>
{
    new Book(Guid.NewGuid(), "The Hobbit", "J.R.R. Tolkien", new DateTime(1937, 9, 21)),
    new Book(Guid.NewGuid(), "The Fellowship of the Ring", "J.R.R. Tolkien", new DateTime(1954, 7, 29)),
    new Book(Guid.NewGuid(), "Clean Code", "Robert C. Martin", new DateTime(2008, 8, 1)),
    new Book(Guid.NewGuid(), "The Pragmatic Programmer", "Andrew Hunt", new DateTime(1999, 10, 20)),
};

var repo = new BookRepository(initialBooks);

var idToFind = initialBooks[0].Id;
Console.WriteLine($"\nGetBookById({idToFind}):");
Console.WriteLine(repo.GetBookById(idToFind)?.ToString() ?? "Not found");

Console.WriteLine("\nFilterByTitle(\"the\"):");
foreach (var b in repo.FilterByTitle("the")) Console.WriteLine(b);

Console.WriteLine("\nFilterByAuthor(\"Tolkien\"):");
foreach (var b in repo.FilterByAuthor("Tolkien")) Console.WriteLine(b);

Console.WriteLine("\nFilterByCreatedAt(1950-01-01 to 2010-01-01):");
foreach (var b in repo.FilterByCreatedAt(new DateTime(1950, 1, 1), new DateTime(2010, 1, 1))) Console.WriteLine(b);

Console.WriteLine("\nSearchByTitleOrAuthor(\"martin\"):");
foreach (var b in repo.SearchByTitleOrAuthor("martin")) Console.WriteLine(b);

Console.WriteLine("\nSearchFirstByTitleOrAuthor(\"Pragmatic\"):");
Console.WriteLine(repo.SearchFirstByTitleOrAuthor("Pragmatic")?.ToString() ?? "Not found");