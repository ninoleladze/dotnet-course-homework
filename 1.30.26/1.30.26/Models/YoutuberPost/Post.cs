using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._30._26.Models.YoutuberPost
{
    internal class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int YoutuberId { get; set; }
       public List<Youtuber> Youtubers { get; set; } = new List<Youtuber>();
    }
}
