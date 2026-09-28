using System;

namespace BooksApp.Models
{
    public class Book
    {
        public Guid Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Author { get; init; } = string.Empty;
        public DateTime CreatedAt { get; init; }

        public Book(Guid id, string title, string author, DateTime createdAt)
        {
            Id = id;
            Title = title;
            Author = author;
            CreatedAt = createdAt;
        }

        public override string ToString() =>
            $"[{Id}] \"{Title}\" by {Author} ({CreatedAt:yyyy-MM-dd})";
    }
}