namespace Movies.DTOs.MoviesDTOs
{
    public class GetHomepageMoviesDTO
    {
        public ICollection<GenreDTO> Genres { get; set; }
    }
}
