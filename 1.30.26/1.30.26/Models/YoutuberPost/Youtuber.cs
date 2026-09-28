using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._30._26.Models.YoutuberPost
{
    internal class Youtuber
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
