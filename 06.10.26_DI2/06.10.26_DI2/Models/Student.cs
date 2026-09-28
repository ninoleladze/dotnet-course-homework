using System;
using System.Collections.Generic;
using System.Text;

namespace _06._10._26_DI2.Models
{
    internal class Student
    {
        public string Name;
        public string Faculty;
        public double GPA;
        public int Age;
        public bool IsActive;

        public void DisplayStudent()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Name:       {Name}");
            Console.WriteLine($"Faculty:    {Faculty}");
            Console.WriteLine($"GPA:        {GPA}");
            Console.WriteLine($"Age:        {Age}");
            Console.WriteLine($"Is Active:  {IsActive}");
            Console.WriteLine("");
        }
    }
}
