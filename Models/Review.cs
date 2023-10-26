using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime TimeCreated { get; set; } = DateTime.UtcNow;

        //each review has one user
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        //each review has one movie
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        

    }
}
