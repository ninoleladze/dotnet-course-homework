using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._20.Models
{
    internal class Comment
    {
     
        public int Id { get; set; }

        public string Content { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Content: {Content}, UserId: {UserId}, PostId: {PostId}";
        }




    }
}
