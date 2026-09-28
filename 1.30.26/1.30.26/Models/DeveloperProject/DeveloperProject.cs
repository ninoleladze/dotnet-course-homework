using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._30._26.Models.DeveloperProject
{
    internal class DeveloperProject
    {
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
