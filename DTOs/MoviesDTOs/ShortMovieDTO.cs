namespace Movies.DTOs.MoviesDTOs
{
    public class ShortMovieDTO
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string Title { get; set; }
        public int ReleaseDate { get; set; }
        public int Rating { get; set; }
        public string PhotoUrl { get; set; }
    }
}
