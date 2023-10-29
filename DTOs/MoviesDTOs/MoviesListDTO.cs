namespace Movies.DTOs.MoviesDTOs
{
    public class MoviesListDTO
    {
        public List<ShortMovieDTO> Movies { get; set; }
        public int totalCount { get; set; }
    }
}
