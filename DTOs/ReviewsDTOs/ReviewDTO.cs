namespace Movies.DTOs.ReviewsDTOs
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime TimeCreated { get; set; } = DateTime.UtcNow;
        public string UserId { get; set; }
        public int MovieId { get; set; }
    }
}
