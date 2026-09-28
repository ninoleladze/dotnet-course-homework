using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1104
{
   public class Book
    {

        private static int _counter = 1;
        public int id {  get; set; }
        public string Title { get; set; }
        public string author { get; set; }
        public int year { get; set; }
       

        public Book()=> id = _counter++;

        public override string ToString()
        {
            return $"ID: {id}, title : {Title}, author: {author}, year : {year}";
        }
    }
}
