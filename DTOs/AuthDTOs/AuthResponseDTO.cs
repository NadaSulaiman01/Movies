namespace Movies.DTOs.AuthDTOs
{
    public class AuthResponseDTO
    {
        public string Role { get; set; } = "User";
        public string Token { get; set; }
        public DateTime? TokenExpiration { get; set; }

        // [JsonIgnore]
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }

    }
}
