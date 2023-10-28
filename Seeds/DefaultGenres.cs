namespace Movies.Seeds
{
    public class DefaultGenres
    {
        public static async Task SeedGenresAsync(ApplicationDbContext context)
        {
            if (!context.Genres.Any())
            {
                context.Genres.Add(new Genre { Name = "Animation" });
                context.Genres.Add(new Genre { Name = "Action" });
                context.Genres.Add(new Genre { Name = "Comedy" });
                context.Genres.Add(new Genre { Name = "Drama" });
                context.Genres.Add(new Genre { Name = "Thriller" });


                await context.SaveChangesAsync();
            }
        }
    }
}
