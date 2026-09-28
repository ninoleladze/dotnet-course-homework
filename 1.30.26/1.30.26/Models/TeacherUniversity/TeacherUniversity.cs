using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._30._26.Models.TeacherUniversity
{
    internal class TeacherUniversity
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int UniversityId { get; set; }
        public University University { get; set; }
    }
}
