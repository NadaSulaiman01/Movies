using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.DTOs.ActorsDTOs;
using Microsoft.AspNetCore.Authorization;
using Movies.DTOs.AuthDTOs;
using Movies.Services.Movies_Service;
using Movies.Validators.Review_Validators;
using System.Collections.ObjectModel;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IValidator<AddMovieDTO> _addMovieValidator;
        private readonly IValidator<EditMovieDTO> _editMovieValidator;
        private static readonly IList<string> _allowedExtenstions = new ReadOnlyCollection<string>(new List<string> { ".jpg", ".png", ".gif", ".jpeg" });
        private const long _MaxAllowedPhotoSize = 1048576;

        public MoviesController(IMovieService movieService, IValidator<AddMovieDTO> addMovieValidator, IValidator<EditMovieDTO> editMovieValidator)
        {
            _movieService = movieService;
            _addMovieValidator = addMovieValidator;
            _editMovieValidator = editMovieValidator;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetHomepageMoviesDTO>>> GetHomepageMovies()
        {
            var response = new ServiceResponse<GetHomepageMoviesDTO>();
            response = await _movieService.GetHomepageMovies();
            return Ok(response);
        }

        [HttpGet("GetMovieById")]
        public async Task<ActionResult<ServiceResponse<FullMovieDTO>>> GetMovieById(int movieId)
        {
            var response = new ServiceResponse<FullMovieDTO>();
            response = await _movieService.GetMovieById(movieId);
            return Ok(response);
        }

        [HttpGet("GetMovieByGenreId")]
        public async Task<ActionResult<ServiceResponse<MoviesListDTO>>> GetMoviesByGenreId(int genreId, int page, int pageSize)
        {

            var paginationCheck = checkPagination(page, pageSize);
            if (!paginationCheck.Success)
            {
                return Ok(paginationCheck);
            }

            var response = new ServiceResponse<MoviesListDTO>();
            response = await _movieService.GetMoviesByGenreId(genreId, page, pageSize);
            return Ok(response);
        }

        [HttpGet("GetAllMovies")]
        public async Task<ActionResult<ServiceResponse<MoviesListDTO>>> GetAllMovies(int page,int pageSize)
        {
            var paginationCheck = checkPagination(page, pageSize);
            if (!paginationCheck.Success)
            {
                return Ok(paginationCheck);
            }
            var response = new ServiceResponse<MoviesListDTO>();
            response = await _movieService.GetAllMovies(page, pageSize);
            return Ok(response);
        }

        //GetMoviesBySearchName

        [HttpGet("GetMoviesBySearchName")]
        public async Task<ActionResult<ServiceResponse<MoviesListDTO>>> GetMoviesBySearchName(string searchInput, int page, int pageSize)
        {
            if (string.IsNullOrEmpty(searchInput))
            {
                var unvalidResult = new ServiceResponseWithoutData()
                {
                    Success = false,
                    Message = "Search input is null or empty"
                };
            }
            var paginationCheck = checkPagination(page, pageSize);
            if (!paginationCheck.Success)
            {
                return Ok(paginationCheck);
            }
            var response = new ServiceResponse<MoviesListDTO>();
            response = await _movieService.GetMoviesBySearchName(searchInput, page, pageSize);
            return Ok(response);
        }

        //GetMoviesSuggestions

        [HttpGet("GetMoviesSuggestions")]
        public async Task<ActionResult<ServiceResponse<List<MovieNameDTO>>>> GetMoviesSuggestions(string searchInput)
        {
            if (string.IsNullOrEmpty(searchInput))
            {
                var unvalidResult = new ServiceResponseWithoutData()
                {
                    Success = false,
                    Message = "Search input is null or empty"
                };
            }
            var response = new ServiceResponse<List<MovieNameDTO>>();
            response = await _movieService.GetMoviesSuggestions(searchInput);
            return Ok(response);
        }

        [HttpGet("GetAllGenres")]
        public async Task<ActionResult<ServiceResponse<List<GenreNameDTO>>>> GetGenreNames()
        {
            var response = new ServiceResponse<List<GenreNameDTO>> ();
            response = await _movieService.GetGenreNames();
            return Ok(response);

        }

        //GetAllMoviesWithoutPagination
        [HttpGet("GetAllMoviesWithoutPagination")]
        public async Task<ActionResult<ServiceResponse<List<MovieNameDTO>>>> GetAllMoviesWithoutPagination()
        {
            var response = new ServiceResponse<List<MovieNameDTO>>();
            response = await _movieService.GetAllMoviesWithoutPagination();
            return Ok(response);
        }

        //GetShortMovieById
        [HttpGet("GetShortMovieById")]
        public async Task<ActionResult<ServiceResponse<ShortMovieDTO>>> GetShortMovieById(int movieId)
        {
            var response = new ServiceResponse<ShortMovieDTO>();
            response = await _movieService.GetShortMovieById(movieId);
            return Ok(response);
        }

        //GetActorsByMovieId
        [HttpGet("GetActorsByMovieId")]
        public async Task<ActionResult<ServiceResponse<List<ShortActorDTO>>>> GetActorsByMovieId(int movieId)
        {
            var response = new ServiceResponse<List<ShortActorDTO>>();
            response = await _movieService.GetActorsByMovieId(movieId);
            return Ok(response);
        }

        //GetReviewsByMovieId
        [HttpGet("GetReviewsByMovieId")]
        public async Task<ActionResult<ServiceResponse<List<ReviewDTO>>>> GetReviewsByMovieId(int movieId, int page, int pageSize, int skipNumber)
        {
            var paginationCheck = checkPagination(page, pageSize);
            if (!paginationCheck.Success)
            {
                return Ok(paginationCheck);
            }
            var response = new ServiceResponse<MovieReviewsDTO>();
            response = await _movieService.GetReviewsByMovieId(movieId, page,pageSize, skipNumber);
            return Ok(response);
        }

        [Authorize(Roles = AppRolesConstants.Admin)]
        [HttpPost("AddMovie")]
        public async Task<ActionResult<ServiceResponse<int>>> AddMovieByAdmin ([FromForm] AddMovieDTO dto)
        {
            var validationResult = _addMovieValidator.Validate(dto);

            // Check if the validation failed
            if (!validationResult.IsValid)
            {
                string errorMessage = string.Join(", ", validationResult.Errors);


                var validationResponse = new ServiceResponseWithoutData
                {
                    Success = false,
                    Message = errorMessage
                };

                return Ok(validationResponse);
            }


            var validImage = new ServiceResponseWithoutData();

            if (!_allowedExtenstions.Contains(Path.GetExtension(dto.Photo.FileName).ToLower()))
            {
                validImage.Success = false;
                validImage.Message = "Only .png, .jpg,.gif photo extensions are allowed!";
                return Ok(validImage);
            }

            if (dto.Photo.Length > _MaxAllowedPhotoSize)
            {
                validImage.Success = false;
                validImage.Message = "Maximum Photo size allowed is 1MB!";
                return Ok(validImage);
            }



            var response = await _movieService.AddMovieByAdmin(dto);
            return Ok(response);
        }

        [Authorize(Roles = AppRolesConstants.Admin)]
        [HttpPut("EditMovie")]
        public async Task<ActionResult<ServiceResponse<int>>> EditMovieByAdmin([FromForm] EditMovieDTO dto)
        {
            var validationResult = _editMovieValidator.Validate(dto);

            // Check if the validation failed
            if (!validationResult.IsValid)
            {
                string errorMessage = string.Join(", ", validationResult.Errors);


                var validationResponse = new ServiceResponseWithoutData
                {
                    Success = false,
                    Message = errorMessage
                };

                return Ok(validationResponse);
            }

            var response = await _movieService.EditMovieByAdmin(dto);
            return Ok(response);
        }

        [HttpGet("GetAllActors")]
        public async Task<ActionResult<ServiceResponse<List<ActorNamesDTO>>>> GetActorNames()
        {
            var response = new ServiceResponse<List<ActorNamesDTO>>();
            response = await _movieService.GetActorNames();
            return Ok(response);

        }

        [Authorize(Roles = AppRolesConstants.Admin)]
        [HttpDelete("DeleteMovieByAdmin")]
        public async Task<ActionResult<ServiceResponse<ReviewDTO>>> DeleteMovieByAdmin(int movieId)
        {

            var response = await _movieService.DeleteMovieByAdmin(movieId);
            return Ok(response);

        }

        [HttpGet("GetMovieWithoutReviews")]
        public async Task<ActionResult<ServiceResponse<MovieWithoutReviewsDTO>>> GetMovieWithoutReviews(int movieId)
        {
            var response = new ServiceResponse<MovieWithoutReviewsDTO>();
            response = await _movieService.GetMovieWithoutReviews(movieId);
            return Ok(response);

        }


        private ServiceResponseWithoutData checkPagination(int page, int pageSize)
        {
            var result = new ServiceResponseWithoutData();
            if (page <= 0 || pageSize <= 0)
            {
                result.Success = false;
                result.Message = "Page and page size should be greater than 0.";
            }
            else
            {
                result.Success = true;
                result.Message = "Pagination parameters are valid.";
            }
            return result;
        }


    }
}
