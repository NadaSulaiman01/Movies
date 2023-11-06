using Movies.DTOs.ActorsDTOs;

namespace Movies.DTOs.MoviesDTOs
{
    public class MovieWithoutReviewsDTO
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseDate { get; set; }
        public int Rating { get; set; }
        public string PhotoUrl { get; set; }
        public GenreNameDTO Genre { get; set; }
        public ICollection<ActorNamesDTO>? Actors { get; set; }
    }
}
