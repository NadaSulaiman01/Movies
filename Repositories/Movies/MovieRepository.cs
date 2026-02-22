namespace Movies.Repositories.Movies
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Movie> Movies => _context.Movies;
        public IQueryable<Genre> Genres => _context.Genres;
        public IQueryable<Actor> Actors => _context.Actors;
        public IQueryable<ActorMovie> ActorMovies => _context.ActorMovie;
        public IQueryable<Review> Reviews => _context.Reviews;

        public Task AddMovieAsync(Movie movie) => _context.Movies.AddAsync(movie).AsTask();

        public Task UpdateMovieAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            return Task.CompletedTask;
        }

        public Task RemoveMovieAsync(Movie movie)
        {
            _context.Movies.Remove(movie);
            return Task.CompletedTask;
        }

        public Task AddActorMovieAsync(ActorMovie actorMovie) =>
            _context.ActorMovie.AddAsync(actorMovie).AsTask();

        public Task<Actor?> FindActorByIdAsync(int actorId) => _context.Actors.FindAsync(actorId).AsTask();

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
