namespace Movies.DTOs.MoviesDTOs
{
    public class EditMovieDTO
    {
        public int Id {  get; set; }
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int GenreId { get; set; }

        public int ReleaseDate { get; set; }

        public int Rating { get; set; }

        public IFormFile? Photo { get; set; }

        public List<int>? ActorIds { get; set; }
    }
}
