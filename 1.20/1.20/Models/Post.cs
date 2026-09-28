using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._20.Models
{
    internal class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();


        override public string ToString()
        {
            int commentsCount = Comments?.Count ?? 0;
           
            string safeTitle = string.IsNullOrEmpty(Title) ? "<empty>" : Title;
            string safeContent = string.IsNullOrEmpty(Content) ? "<empty>" : Content;
            return $"Id: {Id}, Title: {safeTitle}, Content: {safeContent}, UserId: {UserId}, CommentsCount: {commentsCount}";
        }

    }
}
