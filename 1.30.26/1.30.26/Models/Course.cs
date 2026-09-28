using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._30._26.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }

        public List<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();



        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, Duration: {Duration}";
        }
    }
}
