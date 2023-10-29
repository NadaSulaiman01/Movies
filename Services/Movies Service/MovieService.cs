using Movies.DTOs.ActorsDTOs;
using Movies.Models;
using System.Collections.Generic;

namespace Movies.Services.Movies_Service
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<GetHomepageMoviesDTO>> GetHomepageMovies()
        {
            //throw new NotImplementedException();
            var response = new ServiceResponse<GetHomepageMoviesDTO>();
            var genres = await _context.Genres
                .Select(g => new GenreDTO { GenreId = g.GenreId, GenreName = g.Name, })
                .AsNoTracking()
                .ToListAsync();

            if (genres is null)
            {
                response.Success = false;
                response.Message = "There are no genres to fetch";
                return response;
            }

            var homepageDTO = new GetHomepageMoviesDTO();

            foreach (var genre in genres)
            {
                var movies = await _context.Movies
                    .Where(m => m.GenreId == genre.GenreId)
                    .Select(
                        m =>
                            new ShortMovieDTO
                            {
                                MovieId = m.MovieId,
                                GenreId = m.GenreId,
                                GenreName = genre.GenreName,
                                Title = m.Title,
                                Rating = m.Rating,
                                ReleaseDate = m.ReleaseDate,
                                PhotoUrl = m.PhotoUrl
                            }
                    )
                    .OrderByDescending(m => m.Rating)
                    .Take(8)
                    .AsNoTracking()
                    .ToListAsync();

                genre.Movies = movies;
            }

            homepageDTO.Genres = genres;
            response.Data = homepageDTO;
            response.Success = true;
            response.Message = "Movies are fetched successfully";
            return response;
        }

        public async Task<ServiceResponse<FullMovieDTO>> GetMovieById(int movieId)
        {
            var response = new ServiceResponse<FullMovieDTO>();

            var movie = await _context.Movies
                .Where(m => m.MovieId == movieId)
                .Include(m => m.Genre)
                .Include(m => m.Reviews)
                .Include(m => m.ActorMovies)
                .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync();

            if (movie == null)
            {
                response.Success = false;
                response.Message = "There is no movie with this ID: " + movieId;
                return response;
            }

            var dto = new FullMovieDTO();
            dto.MovieId = movie.MovieId;
            dto.Title = movie.Title;
            dto.Description = movie.Description;
            dto.Rating = movie.Rating;
            dto.ReleaseDate = movie.ReleaseDate;
            dto.PhotoUrl = movie.PhotoUrl;
            dto.GenreId = movie.GenreId;
            dto.GenreName = movie.Genre.Name;
            if (movie.Reviews != null)
            {
                dto.Reviews = movie.Reviews
                    .Select(
                        r =>
                            new DTOs.ReviewsDTOs.ReviewDTO
                            {
                                ReviewId = r.ReviewId,
                                Content = r.Content,
                                TimeCreated = r.TimeCreated,
                                UserId = r.UserId,
                                MovieId = r.MovieId
                            }
                    )
                    .ToList();
            }

            if (movie.ActorMovies != null)
            {
                dto.Actors = new List<ShortActorDTO>();
                foreach (var actormovie in movie.ActorMovies)
                {
                    var actorDTO = new ShortActorDTO();
                    actorDTO.ActorId = actormovie.Actor.ActorId;
                    actorDTO.ActorName = actormovie.Actor.ActorName;
                    actorDTO.PhotoUrl = actormovie.Actor.PhotoUrl;
                    dto.Actors.Add(actorDTO);
                }
            }

            response.Data = dto;
            response.Success = true;
            response.Message = "Movie is fetched successfully";

            return response;
        }

        public async Task<ServiceResponse<MoviesListDTO>> GetMoviesByGenreId(int genreId, int page,int pageSize )
        {
            var response = new ServiceResponse<MoviesListDTO>();
           
            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.GenreId == genreId);
            if (genre is null) {
                response.Success = false;
                response.Message = "There is no genre with the given genre id.";
                return response;

            }
            // Calculate the number of items to skip based on the page and page size
            var skipAmount = (page - 1) * pageSize;

            // Query the database to retrieve movies for the specified genre and apply pagination
            var movies = await _context.Movies
                .Where(m => m.GenreId == genreId)
                .Select(m => new ShortMovieDTO
                {
                    MovieId = m.MovieId,
                    GenreId = m.GenreId,
                    GenreName = genre.Name,
                    Title = m.Title,
                    Rating = m.Rating,
                    ReleaseDate = m.ReleaseDate,
                    PhotoUrl = m.PhotoUrl
                })
                .Skip(skipAmount)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            // Calculate the total count of movies for this genre
            var totalMovies = await _context.Movies.Where(m => m.GenreId == genreId).CountAsync();

            var moviesListDTO = new MoviesListDTO();
            moviesListDTO.Movies = movies; 
            moviesListDTO.totalCount = totalMovies;

            response.Data = moviesListDTO;
            response.Success = true;
            response.Message = "Movies are fetched successfully";

            return response;

        }


        public async Task<ServiceResponse<MoviesListDTO>> GetAllMovies(int page, int pageSize)
        {
            var response = new ServiceResponse<MoviesListDTO>();

            // Calculate the number of items to skip based on the page and page size
            var skipAmount = (page - 1) * pageSize;

            // Query the database to retrieve movies for the specified genre and apply pagination
            var movies = await _context.Movies
                .Include(m => m.Genre)
                .Select(m => new ShortMovieDTO
                {
                    MovieId = m.MovieId,
                    GenreId = m.GenreId,
                    GenreName = m.Genre.Name,
                    Title = m.Title,
                    Rating = m.Rating,
                    ReleaseDate = m.ReleaseDate,
                    PhotoUrl = m.PhotoUrl
                })
                .Skip(skipAmount)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            // Calculate the total count of movies for this genre
            var totalMovies = await _context.Movies.CountAsync();

            var moviesListDTO = new MoviesListDTO();
            moviesListDTO.Movies = movies;
            moviesListDTO.totalCount = totalMovies;

            response.Data = moviesListDTO;
            response.Success = true;
            response.Message = "Movies are fetched successfully";

            return response;

        }

        public async Task<ServiceResponse<MoviesListDTO>> GetMoviesBySearchName(string searchInput, int page, int pageSize)
        {
            var response = new ServiceResponse<MoviesListDTO>();
 
            // Calculate the number of items to skip based on the page and page size
            var skipAmount = (page - 1) * pageSize;

            var movies = await _context.Movies
                .Include(m => m.Genre)
                .Select(m => new ShortMovieDTO
                {
                    MovieId = m.MovieId,
                    GenreId = m.GenreId,
                    GenreName = m.Genre.Name,
                    Title = m.Title,
                    Rating = m.Rating,
                    ReleaseDate = m.ReleaseDate,
                    PhotoUrl = m.PhotoUrl
                })
                .Where(m => m.Title.Contains(searchInput))
                .OrderBy(m => m.Title)
                .Skip(skipAmount)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            var totalMovies = await _context.Movies.CountAsync();

            var moviesListDTO = new MoviesListDTO();
            moviesListDTO.Movies = movies;
            moviesListDTO.totalCount = totalMovies;

            response.Data = moviesListDTO;
            response.Success = true;
            response.Message = "Movies are fetched successfully";

            return response;


        }

        public async Task<ServiceResponse<List<MovieNameDTO>>> GetMoviesSuggestions(string searchInput)
        {
            var response = new ServiceResponse<List<MovieNameDTO>>();
          

            var movies = await _context.Movies
                .Include(m => m.Genre)
                .Select(m => new MovieNameDTO
                {
                    MovieId = m.MovieId,
                    MovieTitle = m.Title,
                })
                .Where(m => m.MovieTitle.StartsWith(searchInput))
                .OrderBy(m => m.MovieTitle)
                .AsNoTracking()
                .ToListAsync();

            var moviesNamesList = new List<MovieNameDTO>();
            moviesNamesList = movies;

            response.Data = moviesNamesList;
            response.Success = true;
            response.Message = "Movies are fetched successfully";

            return response;
        }
    }
}
