namespace Movies.Repositories.Movies
{
    public interface IMovieRepository
    {
        IQueryable<Movie> Movies { get; }
        IQueryable<Genre> Genres { get; }
        IQueryable<Actor> Actors { get; }
        IQueryable<ActorMovie> ActorMovies { get; }
        IQueryable<Review> Reviews { get; }

        Task AddMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task RemoveMovieAsync(Movie movie);

        Task AddActorMovieAsync(ActorMovie actorMovie);
        Task<Actor?> FindActorByIdAsync(int actorId);
        Task<int> SaveChangesAsync();
    }
}
