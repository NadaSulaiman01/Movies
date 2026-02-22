namespace Movies.Repositories.Reviews
{
    public interface IReviewRepository
    {
        IQueryable<Movie> Movies { get; }
        IQueryable<Review> Reviews { get; }

        Task AddReviewAsync(Review review);
        Task RemoveReviewAsync(Review review);
        Task<int> SaveChangesAsync();
    }
}
