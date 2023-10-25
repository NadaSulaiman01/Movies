using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Movies.DTOs.AuthDTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Movies.Services.Auth_Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<ApplicationUser> usermanager, ApplicationDbContext context, IConfiguration configuration)
        {
            _usermanager = usermanager;
            _context = context;
            _configuration = configuration;

        }

        public async Task<ServiceResponse<AuthResponseDTO>> LoginUserAsync(LoginRequestDTO request)
        {
            ServiceResponse<AuthResponseDTO> response = new ServiceResponse<AuthResponseDTO>();
            var user = await _usermanager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                response.Message = "Email doesn't exist.";
                response.Success = false;
                return response;

            }
            var result = await _usermanager.CheckPasswordAsync(user, request.Password);
            if (!result)
            {
                response.Message = "Email or password is incorrect.";
                response.Success = false;
                return response;
            }
            string role = AppRolesConstants.User;
            var userRole = await _usermanager.IsInRoleAsync(user, AppRolesConstants.Admin);
            if (userRole)
            {
                role = AppRolesConstants.Admin;

            }


            AuthResponseDTO responseData = new AuthResponseDTO();
            responseData.Token = CreateToken(user.Email, user.Id, role, out DateTime? expiration);
            responseData.TokenExpiration = expiration;
            if (user.RefreshTokens!.Any(t => t.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens!.FirstOrDefault(t => t.IsActive);
                responseData.RefreshToken = activeRefreshToken!.Token;
                responseData.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
                responseData.Role = role;
                response.Data = responseData;

            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                responseData.RefreshToken = refreshToken.Token;
                responseData.RefreshTokenExpiration = refreshToken.ExpiresOn;
                responseData.Role = role;
                response.Data = responseData;
                user.RefreshTokens!.Add(refreshToken);

                await _usermanager.UpdateAsync(user);
            }
            return response;



        }

        public async Task<ServiceResponse<AuthResponseDTO>> RegisterUserAsync(SignUpRequestDTO request)
        {
            ServiceResponse<AuthResponseDTO> response = new ServiceResponse<AuthResponseDTO>();

            var identityUser = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Username,
                Gender = request.Gender,
            };

            var result = await _usermanager.CreateAsync(identityUser, request.Password);
            if (result.Succeeded)
            {
                AuthResponseDTO authResponse = new AuthResponseDTO();
                authResponse.Token = CreateToken(identityUser.Email, identityUser.Id, AppRolesConstants.User, out DateTime? expiration);
                var refreshToken = GenerateRefreshToken();
                authResponse.RefreshToken = refreshToken.Token;
                authResponse.RefreshTokenExpiration = refreshToken.ExpiresOn;
                authResponse.TokenExpiration = expiration;

                response.Data = authResponse;
                identityUser.RefreshTokens = new List<RefreshToken>();
                identityUser.RefreshTokens.Add(refreshToken);

                await _usermanager.UpdateAsync(identityUser);
                var roleResult = await _usermanager.AddToRoleAsync(identityUser, AppRolesConstants.User);
                //if (!roleResult.Succeeded)
                //{
                //    response.Message = roleResult.ToString();
                //    response.Success = false;
                //    return response;

                //}
                await _context.SaveChangesAsync();
                response.Message = "User created successfully";
                response.Success = true;
                return response;

            }
            else
            {
                response.Success = false;
                response.Message = String.Join(" ", result.Errors.Select(e => e.Description).ToList());
                return response;
            }

        }



        public async Task<ServiceResponse<AuthResponseDTO>> RefreshTokenAsync(string refreshToken)
        {

            var response = new ServiceResponse<AuthResponseDTO>();
            var user = await _usermanager.Users.SingleOrDefaultAsync(u => u.RefreshTokens!.Any(t => t.Token == refreshToken));
            if (user == null)
            {
                response.Success = false;
                response.Message = "Invalid refresh token";
                return response;
            }
 
            var retrievedRefreshToken = user.RefreshTokens!.Single(r => r.Token == refreshToken);
            if (!retrievedRefreshToken.IsActive)
            {
                response.Success = false;
                response.Message = "Inactive refresh token";
                return response;

            }
            retrievedRefreshToken.RevokedOn = DateTime.UtcNow;
            var newRefreshToken = GenerateRefreshToken();
            user.RefreshTokens!.Add(newRefreshToken);
            await _usermanager.UpdateAsync(user);
            string role = AppRolesConstants.User;
            var userRole = await _usermanager.IsInRoleAsync(user, AppRolesConstants.Admin);
            if (userRole)
            {
                role = AppRolesConstants.Admin;

            }
            var jwtToken = CreateToken(user.Email, user.Id, role, out DateTime? expiration);

            var responseData = new AuthResponseDTO();
            responseData.Role = role;
            responseData.Token = jwtToken;
            responseData.TokenExpiration = expiration;
            responseData.RefreshToken = newRefreshToken.Token;
            responseData.RefreshTokenExpiration = newRefreshToken.ExpiresOn;
            response.Data = responseData;
            response.Success = true;
            response.Message = "New Tokens have been successfully generated";
            return response;
        }


        private RefreshToken GenerateRefreshToken()
        {
            var RandomNumber = new byte[32];
            using var generator = new RNGCryptoServiceProvider();
            generator.GetBytes(RandomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(10),
                CreatedOn = DateTime.UtcNow
            };
        }


        private string CreateToken(string email, string id, string role, out DateTime? expiration)
        {
            List<Claim> claims = new List<Claim>{
                new Claim("Email",email),
                new Claim(ClaimTypes.NameIdentifier,id),
                new Claim(ClaimTypes.Role, role),
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));


            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = creds,
                Expires = DateTime.UtcNow.AddHours(1)

            };
            expiration = tokenDescriptor.Expires;
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);


            return tokenHandler.WriteToken(token);
        }
    }
}
