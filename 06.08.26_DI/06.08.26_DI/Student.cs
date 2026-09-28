using System;
using System.Collections.Generic;
using System.Text;

namespace _06._08._26_DI
{
    internal class Student
    {
        public string name;
        public int grade;

        public void DisplayStudentInfo()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Grade: {grade}");
        }

        public bool IsPassing()
        {
            return grade >= 5;
        }
    }
}
