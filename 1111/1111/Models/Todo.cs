using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1111.Models
{
    internal class Todo
    {
        private static int _count = 1;
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }= DateTime.Now;
        public int userid { get; set; }

        public Todo() => Id = _count++;


        public override string ToString()
        {
            return $"id: {Id}, title: {Title}, duedate: {DueDate}";
        }

    }
}
