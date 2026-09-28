using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._30._26.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();
        

     
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Email: {Email}, Age: {Age}";
        }

    }
}
