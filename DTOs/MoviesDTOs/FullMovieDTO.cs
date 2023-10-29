using Movies.DTOs.ActorsDTOs;
using Movies.DTOs.ReviewsDTOs;

namespace Movies.DTOs.MoviesDTOs
{
    public class FullMovieDTO
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Rating { get; set; }
        public string PhotoUrl { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public ICollection<ReviewDTO>? Reviews { get; set; }
        public ICollection<ShortActorDTO>? Actors { get; set; }
    }
}
