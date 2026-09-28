using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._30._26.Models.TeacherUniversity
{
    internal class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TeacherUniversity> TeacherUniversities { get; set; } = new List<TeacherUniversity>();
    }
}
