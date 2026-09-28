using SocialMedia.Common;

namespace SocialMedia.Models
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Relation with post (one to many)
        public List<Post> Posts { get; set; } = new();
    }
}
