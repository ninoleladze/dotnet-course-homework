using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3._26.Models
{
    internal class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public User User { get; set; }
        public int UserId { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Like> Likes { get; set; } = new List<Like>();

    }
}
