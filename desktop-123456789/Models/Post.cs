using SocialMedia.Common;

namespace SocialMedia.Models
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }

        // Relation with user (many to one)
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
