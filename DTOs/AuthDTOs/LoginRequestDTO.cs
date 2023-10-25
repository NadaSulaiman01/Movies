using System.ComponentModel.DataAnnotations;

namespace Movies.DTOs.AuthDTOs
{
    public class LoginRequestDTO
    {
        //[Required]
        public string Email { get; set; } 
        //[Required]
        public string Password { get; set; } 
    }
}
