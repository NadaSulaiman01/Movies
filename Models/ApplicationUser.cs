using Microsoft.AspNetCore.Identity;

namespace Movies.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Gender { get; set; } = string.Empty;
        //each user has many refresh tokens
        public List<RefreshToken>? RefreshTokens { get; set; }
        //each user has many reviews
        public List<Review>? Reviews { get; set; }


    }
}
