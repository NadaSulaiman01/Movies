namespace Movies.Seeds
{
    public class DefaultGenres
    {
        public static async Task SeedGenresAsync(ApplicationDbContext context)
        {
            if (!context.Genres.Any())
            {
                context.Genres.Add(new Genre { Name = "Action" });
                context.Genres.Add(new Genre { Name = "Adventure" });
                context.Genres.Add(new Genre { Name = "Horror" });
                context.Genres.Add(new Genre { Name = "Mystery" });
                context.Genres.Add(new Genre { Name = "Fantasy" });
                context.Genres.Add(new Genre { Name = "Thriller" });
                context.Genres.Add(new Genre { Name = "Family" });
                context.Genres.Add(new Genre { Name = "Animation" });

                await context.SaveChangesAsync();
            }
        }
    }
}
