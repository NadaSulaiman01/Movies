namespace Movies.Services.Movies_Service
{
    public interface IMovieService
    {
        Task<ServiceResponse<GetHomepageMoviesDTO>> GetHomepageMovies();
        Task<ServiceResponse<FullMovieDTO>> GetMovieById(int movieId);
        Task<ServiceResponse<MoviesListDTO>> GetMoviesByGenreId(int genreId, int page, int pageSize );
        Task<ServiceResponse<MoviesListDTO>> GetAllMovies(int page, int pageSize);
        Task<ServiceResponse<MoviesListDTO>> GetMoviesBySearchName(string searchInput, int page, int pageSize);
        Task<ServiceResponse<List<MovieNameDTO>>> GetMoviesSuggestions(string searchInput);
        Task<ServiceResponse<List<GenreNameDTO>>> GetGenreNames();


    }
}
