using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._30._26.Models
{
    internal class CourseStudent
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

       

        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

        public override string ToString()
        {
            return $"CourseId: {CourseId}, StudentId: {StudentId}, JoinedAt: {JoinedAt}";
        }


    }
}
