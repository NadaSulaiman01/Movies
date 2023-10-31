namespace Movies.DTOs.ReviewsDTOs
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }
        public string Content { get; set; } = string.Empty;
        public string TimeCreated { get; set; } = Helpers.DateExtractor.FormatConverter(DateTime.Now);
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int MovieId { get; set; }
    }
}
