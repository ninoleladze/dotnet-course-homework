using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._30._26.Models.DeveloperProject
{
    internal class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DeveloperProject> DeveloperProjects { get; set; } = new List<DeveloperProject>();
    }
}
