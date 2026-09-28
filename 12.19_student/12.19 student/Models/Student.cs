using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._19_student.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        override public string ToString()
        {
            return $"Id: {Id}, Username: {Username}, Email: {Email}, Phone: {Phone}";
        }
    }
}
