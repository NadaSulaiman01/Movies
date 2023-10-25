using Movies.DTOs.AuthDTOs;

namespace Movies.Services.Auth_Service
{
    public interface IAuthService
    {
        Task<ServiceResponse<AuthResponseDTO>> RegisterUserAsync(SignUpRequestDTO request);
        Task<ServiceResponse<AuthResponseDTO>> LoginUserAsync(LoginRequestDTO request);

        Task<ServiceResponse<AuthResponseDTO>> RefreshTokenAsync(string refreshToken);
    }
}
