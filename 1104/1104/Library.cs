using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _1104
{
    internal class Library
    {
       private List<Book> books = new List<Book>();

        XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));


        public void loadbooks()
        {
            StreamReader sr = new StreamReader("books.xml");
            var data = serializer.Deserialize (sr);
            sr.Close();
            if (data != null) {

                books = (List<Book>)data;
            }
     
        }

        public void CreateBook()
        {
            Console.WriteLine("enter book title");
            string title = Console.ReadLine();

            Console.WriteLine("enter book author");
            string author = Console.ReadLine();

            Console.WriteLine("enter book year");
            int year = int.Parse(Console.ReadLine());


            Book book = new Book();
            book.author = author;
            book.Title = title;
            book.year = year;


            books.Add(book);
            StreamWriter fs = new StreamWriter("books.xml");
            serializer.Serialize(fs, books);
            fs .Close();
            Console.WriteLine("added succesfully");
        }

        public void deletebook()
        {
            showBooks();
            Console.WriteLine("enter book id:");
            int id = int.Parse(Console.ReadLine());
            var book = books.FirstOrDefault(e => e.id == id);
            if (book == null)
            {

                Console.WriteLine("book not found ");
            }
            else
            {
                books.Remove(book);
                savedata();
            }
        }
        private  void savedata()
        {
            StreamWriter sw = new StreamWriter("books.xlm");
            serializer.Serialize(sw, books);
            sw.Close();
          
        }
                public void showBooks()
                {
                    foreach (Book book in books)
                    {
                        Console.WriteLine(book);
                    }

                }
    }
}