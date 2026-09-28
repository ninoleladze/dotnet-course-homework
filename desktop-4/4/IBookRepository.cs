using System;
using System.Collections.Generic;
using BooksApp.Models;

namespace BooksApp.Repositories
{
    public interface IBookRepository
    {
        Book? GetBookById(Guid id);
        IEnumerable<Book> FilterByTitle(string titleFragment);
        IEnumerable<Book> FilterByAuthor(string authorFragment);
        IEnumerable<Book> FilterByCreatedAt(DateTime from, DateTime to);
        IEnumerable<Book> FilterByCreatedAt(DateTime date);
        IEnumerable<Book> SearchByTitleOrAuthor(string query);   
        Book? SearchFirstByTitleOrAuthor(string query);            
    }
}