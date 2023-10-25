using Microsoft.AspNetCore.Identity;

namespace Movies.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Gender { get; set; } = string.Empty;

        public List<RefreshToken>? RefreshTokens { get; set; }


    }
}
