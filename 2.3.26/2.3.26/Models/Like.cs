using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3._26.Models
{
    internal class Like
    {
        public int Id { get; set; }
        public string Emoji { get; set; }                  
        public int UserId { get; set; }
        public User User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }


    }
}
