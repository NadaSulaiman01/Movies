namespace Movies.DTOs.MoviesDTOs
{
    public class GenreDTO
    {
        public int GenreId { get; set; }
        public string GenreName { get; set;}
        public List<ShortMovieDTO> Movies { get; set; }
    }
}
