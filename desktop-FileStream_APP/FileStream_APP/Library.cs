using System.Xml.Serialization;

namespace FileStream_APP
{
    internal class Library
    {
        private List<Book> booksList = new List<Book>();
        XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));

        public void LoadBooks()
        {
            StreamReader sr = new StreamReader("books.xml");
            var data = serializer.Deserialize(sr);
            sr.Close();

            if (data != null)
            {
                booksList = (List<Book>)data;
            }
        }

        public void CreateBook()
        {
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();

            Console.Write("Enter book author: ");
            string author = Console.ReadLine();

            Console.Write("Enter book year: ");
            int year = int.Parse(Console.ReadLine());

            Book book = new Book();
            book.Author = author;
            book.Title = title;
            book.Year = year;

            booksList.Add(book);
            SaveData();

            Console.WriteLine("Book created successfully.");
        }

        public void DeleteBook()
        {
            ShowBooks();

            Console.Write("Enter book ID: ");
            int bookId = int.Parse(Console.ReadLine());

            var book = booksList.FirstOrDefault(e => e.Id == bookId);

            if (book == null)
            {
                Console.WriteLine("Book not found!");
            }
            else
            {
                booksList.Remove(book);
                SaveData();
            }
        }

        public void ShowBooks()
        {
            foreach (var book in booksList)
            {
                Console.WriteLine(book);
            }
        }

        private void SaveData()
        {
            StreamWriter sw = new StreamWriter("books.xml");
            serializer.Serialize(sw, booksList);
            sw.Close();
        }
    }
}
