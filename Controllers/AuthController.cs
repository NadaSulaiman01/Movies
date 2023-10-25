using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.DTOs.AuthDTOs;
using Movies.Services.Auth_Service;
using Movies.Validators.Auth_Validators;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;

        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<AuthResponseDTO>>> LoginUserAsync(LoginRequestDTO request)
        {

            var validator = new LoginValidator();
            var validationResult = validator.Validate(request);

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

            return Ok(response);

        }

        [HttpPost("signup")]
        public async Task<ActionResult<ServiceResponse<AuthResponseDTO>>> RegisterUserAsync(SignUpRequestDTO request)
        {

            var validator = new SignUpValidator();
            var validationResult = validator.Validate(request);

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
                SameSite = SameSiteMode.None,
                Secure = true
            };

            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }

    }
}
