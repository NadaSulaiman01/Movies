namespace Movies.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        //each genre has many movies
        public ICollection<Movie>? Movie { get; set; }
    }
}
