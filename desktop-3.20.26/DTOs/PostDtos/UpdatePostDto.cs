namespace SocialMedia.DTOs.PostDtos
{
    public class UpdatePostDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }

    }
}
