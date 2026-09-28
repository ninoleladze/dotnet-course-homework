using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1031
{
    internal class Student
    {

        private static int _counter = 1;
        public int Id { get; set; }
        public string Name { get; set; }

        public string lastName { get; set; }
        public int Age { get; set; }

        public int Grade { get; set; }

        public Student()
        {
            Id = _counter++;
        }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name} {lastName}, Age: {Age}, Grade: {Grade}";
        }
    }
}
