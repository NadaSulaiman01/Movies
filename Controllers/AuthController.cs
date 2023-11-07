using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.DTOs.AuthDTOs;
using Movies.Services.Auth_Service;
using Movies.Validators.Auth_Validators;
using System.Web.Http.Results;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IValidator<LoginRequestDTO> _loginValidator;
        private readonly IValidator<SignUpRequestDTO> _signupValidator;

        public AuthController(IAuthService authService, IValidator<LoginRequestDTO> loginValidator, IValidator<SignUpRequestDTO> signupValidator)
        {
            _authService = authService;
            _loginValidator = loginValidator;
            _signupValidator = signupValidator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<AuthResponseDTO>>> LoginUserAsync(LoginRequestDTO request)
        {

            //var validator = new LoginValidator();
            var validationResult = _loginValidator.Validate(request);

            // Check if the validation failed
            if (!validationResult.IsValid)
            {
                string errorMessage =  string.Join(", ", validationResult.Errors);


                var validationResponse = new ServiceResponseWithoutData
                {
                    Success = false,
                    Message = errorMessage
                };

                return Ok(validationResponse);
            }

            var response = await _authService.LoginUserAsync(request);
            if(response.Success) {
                SetRefreshTokenInCookie(response.Data!.RefreshToken, response.Data.RefreshTokenExpiration);
                //SetRefreshTokenInCookie("vvvvv", new DateTime());
            }
            
            return Ok(response);
        }

        [HttpPost("signup")]
        public async Task<ActionResult<ServiceResponse<AuthResponseDTO>>> RegisterUserAsync(SignUpRequestDTO request)
        {

            //var validator = new SignUpValidator();
            var validationResult = _signupValidator.Validate(request);

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

            var response = await _authService.RegisterUserAsync(request);
            if (response.Success)
            {
                SetRefreshTokenInCookie(response.Data!.RefreshToken, response.Data.RefreshTokenExpiration);
                //SetRefreshTokenInCookie("vvvvv", new DateTime());
            }

            return Ok(response);

        }


        [HttpGet("refreshtoken")]
        public async Task<ActionResult<ServiceResponse<AuthResponseDTO>>> RefreshTokenAsync()
        {
            var result = new ServiceResponse<AuthResponseDTO>();
            var refreshToken = Request.Cookies[key: "refreshToken"];
            try
            {
                result = await _authService.RefreshTokenAsync(refreshToken);
                if (result.Success)
                {
                    SetRefreshTokenInCookie(result.Data.RefreshToken, result.Data.RefreshTokenExpiration);
                }
                return Ok(result);
            }
            catch (Exception)
            {

                //throw;
                result.Success = false;
                result.Message = "An error occurred while refreshing the token.";
                return Ok(result);
            }

            
           
        }


        private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime(),
                SameSite = SameSiteMode.Lax,
                Secure = true


                //Add these to allow front end to work
                //SameSite = SameSiteMode.Lax,
                //Secure = true


                //remove those to make it work in swagger again:
                //SameSite = SameSiteMode.Lax,
                //Secure = false
            };

            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }

    }
}
