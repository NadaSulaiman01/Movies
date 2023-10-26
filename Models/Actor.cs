namespace Movies.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public string Gender { get; set; }
        public string PhotoUrl { get; set; }

        //each actor has many movies
        public ICollection<Movie> Movies { get; set; }
    }
}
