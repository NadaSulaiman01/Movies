﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.DTOs.AuthDTOs;
using Movies.Services.Movies_Service;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
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