namespace Movies.Repositories.Reviews
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Movie> Movies => _context.Movies;
        public IQueryable<Review> Reviews => _context.Reviews;

        public Task AddReviewAsync(Review review) => _context.AddAsync(review).AsTask();

        public Task RemoveReviewAsync(Review review)
        {
            _context.Reviews.Remove(review);
            return Task.CompletedTask;
        }

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
