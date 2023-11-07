using Microsoft.AspNetCore.Identity;
using Movies.DTOs.ActorsDTOs;
using Movies.Models;
using System.Collections.Generic;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Movies.Services.Movies_Service
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MovieService(
            ApplicationDbContext context,
            UserManager<ApplicationUser> usermanager,
            ICloudinaryService cloudinaryService,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _context = context;
            _usermanager = usermanager;
            _cloudinaryService = cloudinaryService;
            _httpContextAccessor = httpContextAccessor;
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
                                ReleaseDate = DateExtractor.ExtractYear(m.ReleaseDate),
                                Description = m.Description,
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
                .ThenInclude(r => r.User)
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
            dto.ReleaseDate = DateExtractor.ExtractYear(movie.ReleaseDate);
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
                                TimeCreated = DateExtractor.FormatConverter(r.TimeCreated),
                                UserId = r.UserId,
                                UserName = r.User.UserName,
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

        public async Task<ServiceResponse<MoviesListDTO>> GetMoviesByGenreId(
            int genreId,
            int page,
            int pageSize
        )
        {
            var response = new ServiceResponse<MoviesListDTO>();

            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.GenreId == genreId);
            if (genre is null)
            {
                response.Success = false;
                response.Message = "There is no genre with the given genre id.";
                return response;
            }
            // Calculate the number of items to skip based on the page and page size
            var skipAmount = (page - 1) * pageSize;

            // Query the database to retrieve movies for the specified genre and apply pagination
            var movies = await _context.Movies
                .Where(m => m.GenreId == genreId)
                .Select(
                    m =>
                        new ShortMovieDTO
                        {
                            MovieId = m.MovieId,
                            GenreId = m.GenreId,
                            GenreName = genre.Name,
                            Title = m.Title,
                            Rating = m.Rating,
                            ReleaseDate = DateExtractor.ExtractYear(m.ReleaseDate),
                            Description = m.Description,
                            PhotoUrl = m.PhotoUrl
                        }
                )
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
                .Select(
                    m =>
                        new ShortMovieDTO
                        {
                            MovieId = m.MovieId,
                            GenreId = m.GenreId,
                            GenreName = m.Genre.Name,
                            Title = m.Title,
                            Rating = m.Rating,
                            ReleaseDate = DateExtractor.ExtractYear(m.ReleaseDate),
                            Description = m.Description,
                            PhotoUrl = m.PhotoUrl
                        }
                )
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

        public async Task<ServiceResponse<MoviesListDTO>> GetMoviesBySearchName(
            string searchInput,
            int page,
            int pageSize
        )
        {
            var response = new ServiceResponse<MoviesListDTO>();

            // Calculate the number of items to skip based on the page and page size
            var skipAmount = (page - 1) * pageSize;

            var movies = await _context.Movies
                .Include(m => m.Genre)
                .Select(
                    m =>
                        new ShortMovieDTO
                        {
                            MovieId = m.MovieId,
                            GenreId = m.GenreId,
                            GenreName = m.Genre.Name,
                            Title = m.Title,
                            Rating = m.Rating,
                            Description = m.Description,
                            ReleaseDate = DateExtractor.ExtractYear(m.ReleaseDate),
                            PhotoUrl = m.PhotoUrl
                        }
                )
                .Where(m => m.Title.Contains(searchInput))
                .OrderBy(m => m.Title)
                .Skip(skipAmount)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            var totalMovies = await _context.Movies
                .Where(m => m.Title.Contains(searchInput))
                .CountAsync();

            var moviesListDTO = new MoviesListDTO();
            moviesListDTO.Movies = movies;
            moviesListDTO.totalCount = totalMovies;

            response.Data = moviesListDTO;
            response.Success = true;
            response.Message = "Movies are fetched successfully";

            return response;
        }

        public async Task<ServiceResponse<List<MovieNameDTO>>> GetMoviesSuggestions(
            string searchInput
        )
        {
            var response = new ServiceResponse<List<MovieNameDTO>>();

            var movies = await _context.Movies
                .Select(m => new MovieNameDTO { MovieId = m.MovieId, MovieTitle = m.Title, })
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

        public async Task<ServiceResponse<List<GenreNameDTO>>> GetGenreNames()
        {
            var response = new ServiceResponse<List<GenreNameDTO>>();
            var genre = await _context.Genres
                .Select(g => new GenreNameDTO { GenreId = g.GenreId, GenreName = g.Name })
                .ToListAsync();

            if (genre is null)
            {
                response.Success = false;
                response.Message = "There are no genres to fetch";
                return response;
            }

            response.Data = genre;
            response.Success = true;
            response.Message = "Genres are fetched successfully";
            return response;
        }

        public async Task<ServiceResponse<List<MovieNameDTO>>> GetAllMoviesWithoutPagination()
        {
            //throw new NotImplementedException();
            var response = new ServiceResponse<List<MovieNameDTO>>();

            var movies = await _context.Movies
                .Select(m => new MovieNameDTO { MovieId = m.MovieId, MovieTitle = m.Title, })
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

        public async Task<ServiceResponse<ShortMovieDTO>> GetShortMovieById(int movieId)
        {
            var response = new ServiceResponse<ShortMovieDTO>();

            var movie = await _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.MovieId == movieId)
                .Select(
                    m =>
                        new ShortMovieDTO
                        {
                            MovieId = m.MovieId,
                            Title = m.Title,
                            Description = m.Description,
                            Rating = m.Rating,
                            ReleaseDate = DateExtractor.ExtractYear(m.ReleaseDate),
                            GenreId = m.GenreId,
                            GenreName = m.Genre.Name,
                            PhotoUrl = m.PhotoUrl
                        }
                )
                .FirstOrDefaultAsync();

            if (movie == null)
            {
                response.Success = false;
                response.Message = "No movie with this id exits";
                return response;
            }

            response.Data = movie;
            response.Success = true;
            response.Message = "Movie is fetched successfully";

            return response;
        }

        public async Task<ServiceResponse<List<ShortActorDTO>>> GetActorsByMovieId(int movieId)
        {
            // throw new NotImplementedException();
            var response = new ServiceResponse<List<ShortActorDTO>>();

            bool movieExists = await _context.Movies.AnyAsync(m => m.MovieId == movieId);

            if (!movieExists)
            {
                response.Success = false;
                response.Message = "No movie with this ID exists in the database";
                return response;
            }

            var actors = await _context.ActorMovie
                .Where(a => a.MovieId == movieId)
                .Include(a => a.Actor)
                .Select(
                    a =>
                        new ShortActorDTO
                        {
                            ActorId = a.ActorId,
                            ActorName = a.Actor.ActorName,
                            PhotoUrl = a.Actor.PhotoUrl
                        }
                )
                .ToListAsync();

            response.Data = actors;
            response.Success = true;
            response.Message = "Actors are fetched successfully";

            return response;
        }

        public async Task<ServiceResponse<MovieReviewsDTO>> GetReviewsByMovieId(
            int movieId,
            int page,
            int pageSize,
            int skipNumber
        )
        {
            //throw new NotImplementedException();
            var response = new ServiceResponse<MovieReviewsDTO>();

            bool movieExists = await _context.Movies.AnyAsync(m => m.MovieId == movieId);

            if (!movieExists)
            {
                response.Success = false;
                response.Message = "No movie with this ID exists in the database";
                return response;
            }

            var skipAmount = (page - 1) * pageSize;

            var reviews = await _context.Reviews
                .Where(a => a.MovieId == movieId)
                .Include(r => r.User)
                .OrderByDescending(r => r.TimeCreated)
                .Select(
                    r =>
                        new ReviewDTO
                        {
                            ReviewId = r.ReviewId,
                            Content = r.Content,
                            TimeCreated = DateExtractor.FormatConverter(r.TimeCreated),
                            UserId = r.UserId,
                            UserName = r.User.UserName,
                            MovieId = r.MovieId
                        }
                )
                .Skip(skipAmount + skipNumber)
                .Take(pageSize)
                .ToListAsync();

            int reviewsCount = await _context.Reviews.Where(a => a.MovieId == movieId).CountAsync();

            response.Data = new MovieReviewsDTO();

            response.Data.Reviews = reviews;
            response.Data.reviewsCount = reviewsCount;
            response.Success = true;
            response.Message = "Reviews are fetched successfully";

            return response;
        }

        public async Task<ServiceResponse<int>> AddMovieByAdmin(AddMovieDTO dto)
        {
            //throw new NotImplementedException();
            string PhotoUrl = "";

            ServiceResponse<int> response = new ServiceResponse<int>();

            var user = await _usermanager.FindByIdAsync(GetUserId());
            if (user == null)
            {
                response.Success = false;
                response.Message = "No user found";
                return response;
            }

            var movie = await _context.Movies.FirstOrDefaultAsync(
                m => m.Title.ToLower() == dto.Title.Trim().ToLower()
            );

            if (!(movie is null))
            {
                response.Success = false;
                response.Message = "The movie already exists";
                return response;
            }

            var imageUploadResult = await _cloudinaryService.UploadMovieImageAsync(
                dto.Photo,
                dto.Title,
                dto.GenreId
            );

            if (imageUploadResult.Error == null)
                PhotoUrl = imageUploadResult.SecureUrl.ToString();

            var newMovie = new Movie
            {
                Title = dto.Title,
                GenreId = dto.GenreId,
                Description = dto.Description,
                Rating = dto.Rating,
                ReleaseDate = new DateTime(dto.ReleaseDate, 1, 1),
                PhotoUrl = PhotoUrl,
            };

            _context.Movies.Add(newMovie);
            _context.SaveChanges();

            if (dto.ActorIds != null)
            {
                foreach (var actorId in dto.ActorIds)
                {
                    var actor = _context.Actors.Find(actorId);
                    if (actor != null)
                    {
                        var actorMovie = new ActorMovie { Actor = actor, Movie = newMovie, };
                        _context.ActorMovie.Add(actorMovie);
                    }
                }
                _context.SaveChanges();
            }

            response.Data = newMovie.MovieId;
            response.Success = true;
            response.Message = "Movie has been added successfully";
            return response;
        }

        public async Task<ServiceResponseWithoutData> DeleteMovieByAdmin(int movieId)
        {
            //throw new NotImplementedException();
            var response = new ServiceResponseWithoutData();
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.MovieId == movieId);

            if (movie is null)
            {
                response.Success = false;
                response.Message = "Inavlid movie Id";
                return response;
            }
            string photoUrl = movie.PhotoUrl;
            string photoPath = GetPhotoPath(photoUrl);
            _context.Movies.Remove(movie);
            int rowsAffected = await _context.SaveChangesAsync();

            if (rowsAffected > 0)
            {
                if (!string.IsNullOrEmpty(photoPath) || string.IsNullOrEmpty(photoUrl))
                {
                    await _cloudinaryService.DeleteImageAsync(photoPath);
                    response.Success = true;
                    response.Message = "Movie has been deleted successfully.";
                    return response;
                }
            }
            response.Success = true;
            response.Message =
                "Movie has been deleted successfully but image was not deleted from cloudinary.";
            return response;
        }

        private String GetUserId() =>
            _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        public async Task<ServiceResponse<List<ActorNamesDTO>>> GetActorNames()
        {
            var response = new ServiceResponse<List<ActorNamesDTO>>();
            var actors = await _context.Actors
                .Select(a => new ActorNamesDTO { Id = a.ActorId, Name = a.ActorName })
                .ToListAsync();

            //if (actors is null)
            //{
            //    response.Success = false;
            //    response.Message = "There are no actors to fetch";
            //    return response;
            //}

            response.Data = actors;
            response.Success = true;
            response.Message = "Actors are fetched successfully";
            return response;
        }

        public async Task<ServiceResponse<MovieWithoutReviewsDTO>> GetMovieWithoutReviews(
            int movieId
        )
        {
            //throw new NotImplementedException();
            var response = new ServiceResponse<MovieWithoutReviewsDTO>();
            var movie = await _context.Movies
                .Include(m => m.Genre)
                .Include(m => m.ActorMovies)
                .ThenInclude(m => m.Actor)
                .FirstOrDefaultAsync(m => m.MovieId == movieId);

            if (movie is null)
            {
                response.Success = false;
                response.Message = "Inavlid movie Id";
                return response;
            }

            var dto = new MovieWithoutReviewsDTO();
            dto.MovieId = movie.MovieId;
            dto.Title = movie.Title;
            dto.Description = movie.Description;
            dto.Rating = movie.Rating;
            dto.ReleaseDate = DateExtractor.ExtractYear(movie.ReleaseDate);
            dto.PhotoUrl = movie.PhotoUrl;
            dto.Genre = new GenreNameDTO { GenreId = movie.GenreId, GenreName = movie.Genre.Name };
            dto.Actors = new List<ActorNamesDTO>();
            if (!(movie.ActorMovies is null))
            {
                foreach (var am in movie.ActorMovies)
                {
                    dto.Actors.Add(
                        new ActorNamesDTO { Id = am.ActorId, Name = am.Actor.ActorName }
                    );
                }
            }

            response.Data = dto;
            response.Success = true;
            response.Message = "Movie data is fetched successfully";
            return response;
        }

        private String GetPhotoPath(string publicID)
        {
            string resultOne = "";
            string resultTwo = "";
            string movies = "Movies";
            for (int i = 0; i < publicID.Length; i++)
            {
                if ((i + 6) <= publicID.Length - 1)
                {
                    if (publicID.Substring(i, 6) == movies)
                    {
                        resultOne = publicID.Substring(i);
                        break;
                    }
                }
                else
                {
                    return "";
                }
            }
            int count = 0;
            if (!string.IsNullOrEmpty(resultOne))
            {
                for (int i = resultOne.Length - 1; i >= 0; i--)
                {
                    count++;
                    if (resultOne[i] == '.')
                    {
                        resultTwo = resultOne.Substring(0, resultOne.Length - count);
                        break;
                    }
                }
            }
            return resultTwo;
        }

        public async Task<ServiceResponse<int>> EditMovieByAdmin(EditMovieDTO dto)
        {
            //throw new NotImplementedException();
            var response = new ServiceResponse<int>();
            var movie = await _context.Movies
                .Include(m => m.Genre)
                .Include(m => m.ActorMovies)
                .FirstOrDefaultAsync(m => m.MovieId == dto.Id);

            if (movie is null)
            {
                response.Success = false;
                response.Message = "Inavlid movie Id";
                return response;
            }

            //var movieWithSameData = await _context.Movies
            //    .Where(
            //        m =>
            //            (m.MovieId != dto.Id)
            //            && (
            //                (m.Title.ToLower().Trim()) == (dto.Title.ToLower().Trim())
            //                && (DateExtractor.ExtractYear(m.ReleaseDate) == (dto.ReleaseDate))
            //            )
            //    )
            //    .FirstOrDefaultAsync();

            var movies = await _context.Movies.Where(m => m.MovieId != dto.Id).ToListAsync();

            var movieWithSameData = movies.FirstOrDefault(
                m =>
                    m.Title.ToLower().Trim() == dto.Title.ToLower().Trim()
                    && DateExtractor.ExtractYear(m.ReleaseDate) == dto.ReleaseDate
            );

            if (movieWithSameData != null)
            {
                response.Success = false;
                response.Message = "Another Movie with the same name and release year exists.";
                return response;
            }

            movie.Title = dto.Title.Trim();
            movie.Description = dto.Description.Trim();
            movie.ReleaseDate = new DateTime(dto.ReleaseDate, 1, 1);
            movie.Rating = dto.Rating;
            movie.GenreId = dto.GenreId;
            movie.ActorMovies = dto.ActorIds
                .Select(id => new ActorMovie { MovieId = movie.MovieId, ActorId = id })
                .ToList();

            if (!(dto.Photo is null))
            {
                var imageUploadResult = await _cloudinaryService.UploadMovieImageAsync(
                    dto.Photo,
                    dto.Title,
                    dto.GenreId
                );

                if (imageUploadResult.Error == null)
                {
                    string photoUrl = movie.PhotoUrl;
                    string photoPath = GetPhotoPath(photoUrl);
                    if (!string.IsNullOrEmpty(photoPath) || string.IsNullOrEmpty(photoUrl))
                    {
                        movie.PhotoUrl = imageUploadResult.SecureUrl.ToString();
                         _cloudinaryService.DeleteImageAsync(photoPath);
                        

                    }
                    else
                    {
                        movie.PhotoUrl = imageUploadResult.SecureUrl.ToString();
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "There was a problem uploading the new poster";
                    return response;
                }
            }

            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();

            response.Data = movie.MovieId;
            response.Success = true;
            response.Message = "The Movie has been edited successfully";
            return response;
        }
    }
}
