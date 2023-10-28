namespace Movies.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set;}
        public int Rating { get; set;}
        public string PhotoUrl { get; set; }

        //each movie has one genre
        public int GenreId { get; set;}
        public Genre Genre { get; set;}

        //each movie many reviews
        public ICollection<Review>? Reviews { get; set; }

        //each movie has many actors
        //public ICollection<Actor> Actors { get; set; }
        public ICollection<ActorMovie>? ActorMovies { get; set; }

    }
}
