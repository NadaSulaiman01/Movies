using Movies.Models;
using Movies.Services.Cloudinary_Service;

namespace Movies.Seeds
{
    public class DefaultMovies
    {
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ApplicationDbContext _context;

        public DefaultMovies(ICloudinaryService cloudinaryService, ApplicationDbContext context)
        {
            _cloudinaryService = cloudinaryService;
            _context = context;
        }

        public async Task SeedMoviesAsync()
        {
            if (!_context.Movies.Any())
            {


                var movies = new List<Movie>
            {

                    //Seed animation movies with genre id 1

                new Movie
                {
                    Title = "gulliver's travels",
                    Description = "Lemuel Gulliver washes onto the beach of Lilliput after a shipwreck. He becomes involved in a war between Lilliput and Blefuscu and eventually helps bring about peace. A classic tale of diplomacy and cooperation.",
                    ReleaseDate = new DateTime(1939, 12, 22),
                    Rating = 4,
                    GenreId = 1,
                    PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMTU0NTUwOTM3Nl5BMl5BanBnXkFtZTcwMDA3NjIwNA@@._V1_QL75_UX190_CR0", "gulliver's travels", 1)
                },
                new Movie
                {
                    Title = "elmer's candid camera",
                    Description = "Elmer is reading a book on how to photograph wildlife and harasses Happy Rabbit while attempting to take photos. Bugs outsmarts Elmer, leading to a series of comical events.",
                    ReleaseDate = new DateTime(1940, 3, 2),
                    Rating = 3,
                    GenreId = 1,
                    PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BNTc1MzIwZjEtOGZhMy00MDdhLTg5OWUtMDQ0MTU5OWY5MTIzXkEyXkFqcGdeQXVyNjc2NTQzMjU@._V1_QL75_UX190_CR0", "elmer's candid camera", 1)
                },
                new Movie
                {
                    Title = "pinocchio",
                    Description = "Jiminy Cricket narrates the story of Geppetto, a woodworker who wishes for his marionette, Pinocchio, to become a real boy. The film follows Pinocchio's adventures, including encounters with the Blue Fairy, Honest John, and a frightening trip to Pleasure Island.",
                    ReleaseDate = new DateTime(1940, 2, 7),
                    Rating = 5,
                    GenreId = 1,
                    PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BNDViYmViNWItMTY0Ny00YWI0LTg2MDktY2M1NDI5NzUyYWM4XkEyXkFqcGdeQXVyMzE4MDkyNTA@._V1_UX256", "pinocchio", 1)
                },
                new Movie
                {
                    Title = "all this and rabbit stew",
                    Description = "Bugs Bunny outsmarts a hunter named Willoughby in a series of comical traps and chases. The hunter's attempts to catch Bugs lead to hilarious and unexpected outcomes.",
                    ReleaseDate = new DateTime(1941, 9, 20),
                    Rating = 4,
                    GenreId = 1,
                    PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BYjE3Y2Q3OTctOTU1Yy00NzQwLWIyZmUtMzVkZmRjMzk5MTQ0XkEyXkFqcGdeQXVyNTE1NjY5Mg@@._V1_QL75_UY281_CR5", "all this and rabbit stew", 1)
                },
                new Movie
                {
                    Title = "dumbo",
                    Description = "Dumbo is a young elephant with oversized ears, ridiculed by others. Separated from his mother, Dumbo must overcome his challenges, including a drunken adventure and a remarkable ability to fly, to find acceptance and happiness.",
                    ReleaseDate = new DateTime(1941, 10, 23),
                    Rating = 5,
                    GenreId = 1,
                    PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BNjMxMDE0MDI1Ml5BMl5BanBnXkFtZTgwMzExNTU3NjM@._V1_QL75_UX190_CR0", "dumbo", 1)
                },
                new Movie
                {
                    Title = "the heckling hare",
                    Description = "Bugs Bunny is hunted by a dog named Willoughby. Bugs cleverly tricks the dog into various traps, leading to comical and unexpected consequences.",
                    ReleaseDate = new DateTime(1941, 5, 2),
                    Rating = 4,
                    GenreId = 1,
                    PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZDA2YTZkYWQtYjBhOC00MTYzLWI1OGYtNDg0YTM5OWRmNDU4XkEyXkFqcGdeQXVyNTE1NjY5Mg@@._V1_QL75_UX190_CR0", "the heckling hare", 1)
                },
                            new Movie
            {
                Title = "Hiawatha's Rabbit Hunt",
                Description = "Hiawatha's Rabbit Hunt is a classic animation that brings the adventures of Hiawatha to life.",
                ReleaseDate = new DateTime(1941, 8, 9),
                Rating = 1,
                GenreId = 1,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BM2E3YjJkY2MtODc0MS00OWU5LWFiZjgtZWZlMzRiZjNlYmNhXkEyXkFqcGdeQXVyNjc2NTQzMjU@._V1_QL75_UX190_CR0", "Hiawatha's Rabbit Hunt", 1)
            },
            new Movie
            {
                Title = "Mister Bug Goes to Town",
                Description = "Mister Bug Goes to Town is a delightful animation that follows the journey of a bug in the big city.",
                ReleaseDate = new DateTime(1941, 12, 5),
                Rating = 2,
                GenreId = 1,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZjEyNGQ2ODUtMGExNi00NzViLWFiMmItMzEyMjY1YmI2NTZlXkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_QL75_UX190_CR0", "Mister Bug Goes to Town", 1)
            },
            new Movie
            {
                Title = "Mr. Bug Goes to Town",
                Description = "Mr. Bug Goes to Town is a heartwarming animation about the adventures of a bug community.",
                ReleaseDate = new DateTime(1941, 12, 5),
                Rating = 3,
                GenreId = 1,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZjEyNGQ2ODUtMGExNi00NzViLWFiMmItMzEyMjY1YmI2NTZlXkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_QL75_UX190_CR0", "Mr. Bug Goes to Town", 1)
            },
            new Movie
            {
                Title = "Pantry Panic",
                Description = "Pantry Panic is a hilarious animation that depicts the chaos in a kitchen when the owner goes on vacation.",
                ReleaseDate = new DateTime(1941, 6, 28),
                Rating = 4,
                GenreId = 1,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMDI0YWVlOWYtMTUwNy00MmVmLTk4MjEtODE3NDU0NWI2NmFiXkEyXkFqcGdeQXVyNzU3NTk0NjA@._V1_QL75_UX190_CR0", "Pantry Panic", 1)
            },
            new Movie
            {
                Title = "Tortoise Beats Hare",
                Description = "Tortoise Beats Hare is a classic animation that teaches the value of patience and determination.",
                ReleaseDate = new DateTime(1941, 7, 5),
                Rating = 5,
                GenreId = 1,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BYTVjMDBlNDktMzgyYy00YTgwLThhYTYtZjE1OTYwMWUwZmVhXkEyXkFqcGdeQXVyMTEzNzc4Nzky._V1_QL75_UY281_CR4", "Tortoise Beats Hare", 1)
            },
            new Movie
            {
                Title = "Wabbit Twouble",
                Description = "Wabbit Twouble is a hilarious animation featuring the iconic Bugs Bunny and his adventures.",
                ReleaseDate = new DateTime(1941, 12, 20),
                Rating = 3,
                GenreId = 1,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZDI3ZjEzNzQtZjU3OC00ZDExLTg0ZTAtYTBjMTUxYzFhYzkyXkEyXkFqcGdeQXVyNTE1NjY5Mg@@._V1_QL75_UX190_CR0", "Wabbit Twouble", 1)
            },

            new Movie
            {
                Title = "The Wabbit Who Came to Supper",
                Description = "The Wabbit Who Came to Supper is a classic animation featuring the iconic Bugs Bunny.",
                ReleaseDate = new DateTime(1942, 5, 23),
                Rating = 3,
                GenreId = 1,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZjk3NmU4OGQtMmY4Zi00MWJjLWFkM2EtOTUyZmVlZDdmNjM2XkEyXkFqcGdeQXVyMTY5Nzc4MDY@._V1_QL75_UX190_CR0", "The Wabbit Who Came to Supper", 1)
            },
            new Movie
            {
                Title = "Falling Hare",
                Description = "Falling Hare is a classic animation where Bugs Bunny faces comedic challenges.",
                ReleaseDate = new DateTime(1943, 8, 1),
                Rating = 4,
                GenreId = 1,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BNzdkYjAxMWQtYWY2NC00YTczLTlmNzMtYTE0OGQ0YzRmMDkxXkEyXkFqcGdeQXVyMTA0MTM5NjI2._V1_QL75_UX190_CR0", "Falling Hare", 1)
            },

            new Movie
            {
                Title = "Draftee Daffy",
                Description = "Draftee Daffy is a humorous animation that follows the misadventures of Daffy Duck.",
                ReleaseDate = new DateTime(1945, 4, 27),
                Rating = 1,
                GenreId = 1,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZWE4OTJiM2ItOGI5NS00MTM3LTk5YjgtZGNiNzg2MzI5NjdiXkEyXkFqcGdeQXVyNjc2NTQzMjU@._V1_QL75_UX190_CR0", "Draftee Daffy", 1)
            },

            new Movie
            {
                Title = "The Friendly Ghost",
                Description = "The Friendly Ghost is an iconic animation featuring the beloved character Casper the friendly ghost.",
                ReleaseDate = new DateTime(1945, 5, 5),
                Rating = 5,
                GenreId = 1,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMTI1OTIxMTQwNl5BMl5BanBnXkFtZTcwMTI5MzQyMQ@@._V1_QL75_UY281_CR3", "The Friendly Ghost", 1)
            },


            //Add action movies with genre id 2
            new Movie
            {
                Title = "The Great Train Robbery",
                Description = "The Great Train Robbery is a thrilling action film depicting a daring train heist. Join the outlaws as they scheme, rob, and make a run for it. It's a high-stakes adventure that will keep you on the edge of your seat.",
                ReleaseDate = new DateTime(1903, 12, 1),
                Rating = 4,
                GenreId = 2,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BOWE4M2UwNWEtODFjOS00M2JiLTlhOGQtNTljZjI5ZTZlM2MzXkEyXkFqcGdeQXVyNjUwNzk3NDc@._V1_QL75_UX190_CR0", "The Great Train Robbery", 2)
            },
            new Movie
            {
                Title = "The Fight for Freedom",
                Description = "The Fight for Freedom is an action-packed film set in a world of conflict and resistance. Join the heroes in their battle for freedom and justice. It's a story of courage and determination.",
                ReleaseDate = new DateTime(1942, 2, 19),
                Rating = 3,
                GenreId = 2,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMjE2MTA5MzQ0Nl5BMl5BanBnXkFtZTgwNTk4OTIyMDE@._V1_QL75_UX190_CR0", "The Fight for Freedom", 2)
            },
            new Movie
            {
                Title = "The Call of the North",
                Description = "The Call of the North is an action-adventure film that takes you on an expedition to the frozen wilderness. Join the explorers as they face danger and uncover the secrets of the North.",
                ReleaseDate = new DateTime(1921, 12, 18),
                Rating = 3,
                GenreId = 2,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMWE5MzlmZTgtNjBjZC00MGM3LTg4YmMtOWRjNWMyZmMyYjY5XkEyXkFqcGdeQXVyMjUxODE0MDY@._V1_QL75_UX190_CR0", "The Call of the North", 2)
            },
            new Movie
            {
                Title = "Rose of the Rancho",
                Description = "Rose of the Rancho is an action-packed Western film. Join Rose in her journey through the Wild West as she faces bandits and fights for justice. It's a tale of bravery and determination.",
                ReleaseDate = new DateTime(1936, 8, 14),
                Rating = 3,
                GenreId = 2,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZGMwZjhmMzQtMTQxYy00MWM1LThiZjYtNjI2OGJhYzNhMjMxL2ltYWdlXkEyXkFqcGdeQXVyNzA4ODc3ODU@._V1_QL75_UX190_CR0", "Rose of the Rancho", 2)
            },
            new Movie
            {
                Title = "Salomy Jane",
                Description = "Salomy Jane is an action-packed Western film that follows the adventures of the titular character. Join Salomy Jane as she navigates the challenges of the Wild West. It's a story of courage and grit.",
                ReleaseDate = new DateTime(1914, 2, 5),
                Rating = 4,
                GenreId = 2,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMjUxODllY2UtMDlmYy00ZjYwLWIzYTYtZTEyNGVhNjUyN2NiXkEyXkFqcGdeQXVyNzk3ODM4NQ@@._V1_QL75_UY281_CR8", "Salomy Jane", 2)
            },
            new Movie
            {
                Title = "Carmen",
                Description = "Carmen is a thrilling action film based on the famous opera. Follow the fiery and passionate Carmen as she weaves her spell over men, leading to love, betrayal, and tragedy.",
                ReleaseDate = new DateTime(1915, 12, 30),
                Rating = 5,
                GenreId = 2,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMjE2MjA0OTYxNF5BMl5BanBnXkFtZTcwNTQ1MzMzMQ@@._V1_QL75_UY281_CR4", "Carmen", 2)
            },
            new Movie
            {
                Title = "Bucking Broadway",
                Description = "Bucking Broadway is a thrilling action film set in the world of rodeo and ranch life. Join the cowboys and cowgirls as they face danger, compete, and find love in the Old West.",
                ReleaseDate = new DateTime(1917, 2, 11),
                Rating = 4,
                GenreId = 2,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BYmQxYmM4YTctZjBkMy00OTIwLTgyNmYtMjgxOGY0MTg4NWY3XkEyXkFqcGdeQXVyNDY1NzU5NjY@._V1_QL75_UY281_CR4", "Bucking Broadway", 2)
            },
            new Movie
            {
                Title = "Cheyenne's Pal",
                Description = "Cheyenne's Pal is an action-adventure film that explores the bond between a cowboy and his loyal horse. Join them as they face challenges and embark on thrilling escapades.",
                ReleaseDate = new DateTime(1917, 6, 18),
                Rating = 3,
                GenreId = 2,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BM2U5ZGM4OTItMTFiNi00YmEwLWJlMGUtODU2NGMwMzIwYjFkXkEyXkFqcGdeQXVyOTc5MDI5NjE@._V1_QL75_UY281_CR94", "Cheyenne's Pal", 2)
            },
            new Movie
            {
                Title = "Golden Rule Kate",
                Description = "Golden Rule Kate is an action film that tells the story of a strong-willed and independent woman navigating the challenges of the Old West. Join her on an adventure filled with courage and determination.",
                ReleaseDate = new DateTime(1917, 12, 9),
                Rating = 3,
                GenreId = 2,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BN2Q1OTEzZGUtMzI5My00MTM2LWEyMTgtZDcwYzAzZWI4YjMwXkEyXkFqcGdeQXVyNjA5MTAzODY@._V1_QL75_UY281_CR8", "Golden Rule Kate", 2)
            },
            new Movie
            {
                Title = "A Modern Musketeer",
                Description = "A Modern Musketeer is an action-adventure film following the daring exploits of a modern-day musketeer. Join him in swashbuckling adventures, romance, and chivalry.",
                ReleaseDate = new DateTime(1917, 10, 21),
                Rating = 4,
                GenreId = 2,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMTBmNGUyODQtZTU1NC00YTE5LWJiZDMtZDI0ZmNlYzA3MGE0XkEyXkFqcGdeQXVyNjA5MTAzODY@._V1_QL75_UY281_CR2", "A Modern Musketeer", 2)
            },
             new Movie
            {
                Title = "Reaching for the Moon",
                Description = "Reaching for the Moon is an action film that follows the journey of a determined individual striving for greatness. Join the protagonist as they face challenges, overcome obstacles, and reach for the moon.",
                ReleaseDate = new DateTime(1917, 12, 13),
                Rating = 3,
                GenreId = 2,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMTg2MDMwNzk4Nl5BMl5BanBnXkFtZTgwNjYyMDQ1MDE@._V1_QL75_UX190_CR0", "Reaching for the Moon", 2)
            },

            new Movie
            {
                Title = "Straight Shooting",
                Description = "Straight Shooting is an action film set in the Wild West. Join the cowboys and outlaws as they engage in gunfights, showdowns, and a quest for justice. It's a tale of courage and revenge.",
                ReleaseDate = new DateTime(1917, 6, 25),
                Rating = 3,
                GenreId = 2,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMThiNTNkMGEtOGRlZC00ZGFhLWI2NTEtYWI5ZGZhYTUwNmRjXkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_QL75_UY281_CR2", "Straight Shooting", 2)
            },
            new Movie
            {
                Title = "He Comes Up Smiling",
                Description = "He Comes Up Smiling is an action film that takes you on a journey of unexpected adventure and discovery. Join the protagonist as they navigate the twists and turns of life with a smile.",
                ReleaseDate = new DateTime(1918, 6, 3),
                Rating = 4,
                GenreId = 2,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BNGIxMTU5NTMtMmMxMS00NDVmLTkxM2UtMTBiOGI1MzM1M2ZhXkEyXkFqcGdeQXVyNDY1NzU5NjY@._V1_QL75_UY281_CR2", "He Comes Up Smiling", 2)
            },
            new Movie
            {
                Title = "Hell Bent",
                Description = "Hell Bent is an action film that tells the tale of a relentless pursuit for justice. Join the hero as he confronts danger and seeks to set things right in a lawless land.",
                ReleaseDate = new DateTime(1918, 1, 20),
                Rating = 3,
                GenreId = 2,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMTc4MTgzNDgwNV5BMl5BanBnXkFtZTgwNzM0OTczNzE@._V1_QL75_UY281_CR116", "Hell Bent", 2)
            },

            new Movie
            {
                Title = "The Scarlet Drop",
                Description = "The Scarlet Drop is an action film that takes you to a world of intrigue and mystery. Join the characters as they uncover secrets and face danger in the pursuit of justice.",
                ReleaseDate = new DateTime(1918, 2, 3),
                Rating = 3,
                GenreId = 2,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZjNhZDY5ZjUtM2E5YS00NGM3LWIxNzAtNDRiNTgyY2EyOGJmXkEyXkFqcGdeQXVyNjE5MjUyOTM@._V1_QL75_UX190_CR0", "The Scarlet Drop", 2)
            },
            new Movie
            {
                Title = "Tarzan of the Apes",
                Description = "Tarzan of the Apes is an action-adventure film that tells the classic story of Tarzan's origins in the jungle and his encounters with various dangers and creatures. It's a tale of survival and discovery.",
                ReleaseDate = new DateTime(1918, 1, 27),
                Rating = 4,
                GenreId = 2,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BNTk2MTMyZjQtNjEzYi00MmE3LTlkNmItNWYyZmNhNTdjMTBkXkEyXkFqcGdeQXVyMzg1ODEwNQ@@._V1_QL75_UX190_CR0", "Tarzan of the Apes", 2)
            },
            new Movie
            {
                Title = "A Gun Fightin' Gentleman",
                Description = "A Gun Fightin' Gentleman is an action film that follows the life of a gentleman with a talent for handling firearms. Join him in battles, duels, and moments of honor.",
                ReleaseDate = new DateTime(1919, 2, 3),
                Rating = 3,
                GenreId = 2,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZGM3NTFhZGEtNWZmOC00YmE2LTkzM2QtYzBiMjFmYmRkOGU5XkEyXkFqcGdeQXVyNjA5MTAzODY@._V1_QL75_UY281_CR7", "A Gun Fightin' Gentleman", 2)
            },
            //seed comedy movies with genre id of 3
             new Movie
            {
                Title = "Petticoat Camp",
                Description = "Petticoat Camp is a comedy film filled with humor and laughter. Join the hilarious antics of the characters as they navigate the challenges of life with wit and humor.",
                ReleaseDate = new DateTime(1916, 9, 28),
                Rating = 3,
                GenreId = 3,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BYjlkNGFmYjAtOTk2OS00ZmE3LWIxNTAtN2E0MmEyY2M5YzEzXkEyXkFqcGdeQXVyNTM3MDMyMDQ@._V1_QL75_UY281_CR11", "Petticoat Camp", 3)
            },
            new Movie
            {
                Title = "Barney Oldfield's Race for a Life",
                Description = "Barney Oldfield's Race for a Life is a comedy film that follows the adventurous journey of Barney Oldfield. Join him in a race filled with laughs and surprises.",
                ReleaseDate = new DateTime(1913, 2, 4),
                Rating = 4,
                GenreId = 3,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BNGZhMzk5NDQtMDQ1ZC00YTQ5LWIwMTQtZjVlOGI0MGM5NGJiL2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyMTE2NzA0Ng@@._V1_QL75_UY281_CR99", "Barney Oldfield's Race for a Life", 3)
            },
            new Movie
            {
                Title = "Bob's Baby",
                Description = "Bob's Baby is a comedy film that tells the story of a humorous misadventure involving a baby. Join the characters as they deal with unexpected challenges.",
                ReleaseDate = new DateTime(1915, 11, 29),
                Rating = 3,
                GenreId = 3,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMGQ4OTQ5NTItMGEwNS00ZmZlLTlmMGUtOWM5M2E4ZThjMDA3XkEyXkFqcGdeQXVyMTEwODg2MDY@._V1_QL75_UY281_CR73", "Bob's Baby", 3)
            },
            new Movie
            {
                Title = "Cohen Saves the Flag",
                Description = "Cohen Saves the Flag is a comedy film filled with hilarious patriotic endeavors. Join Cohen in his humorous journey to save the flag.",
                ReleaseDate = new DateTime(1913, 6, 14),
                Rating = 4,
                GenreId = 3,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMTdkYTlkZDEtYTgyMS00MTU4LWJhMzctODY0NWE5Yjg0Y2ZiXkEyXkFqcGdeQXVyMDUyOTUyNQ@@._V1_QL75_UY281_CR90", "Cohen Saves the Flag", 3)
            },
            new Movie
            {
                Title = "A Busy Day",
                Description = "A Busy Day is a comedy film that follows the humorous adventures of the characters on a day filled with chaos and laughter. Join them in their busy and funny day.",
                ReleaseDate = new DateTime(1914, 4, 2),
                Rating = 3,
                GenreId = 3,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZDQ0YjJjMmEtZGUzMC00MWYyLWI2YjEtYjA4ZTMyMDE0OTRlXkEyXkFqcGdeQXVyNzQxNDExNTU@._V1_QL75_UY281_CR10", "A Busy Day", 3)
            },
            new Movie
            {
                Title = "Caught in a Cabaret",
                Description = "Caught in a Cabaret is a comedy film that takes you on a hilarious cabaret adventure. Join the characters as they navigate misunderstandings and comedy.",
                ReleaseDate = new DateTime(1914, 4, 27),
                Rating = 4,
                GenreId = 3,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BOGY3MDVkYmQtYWY5MS00MjVlLThmZjEtMThjYTQ1MWU3N2I2XkEyXkFqcGdeQXVyNjA5MTAzODY@._V1_QL75_UX190_CR0", "Caught in a Cabaret", 3)
            },
            new Movie
            {
                Title = "Caught in the Rain",
                Description = "Caught in the Rain is a comedy film filled with comedic rain-soaked adventures. Join the characters in this humorous and wet escapade.",
                ReleaseDate = new DateTime(1914, 5, 7),
                Rating = 3,
                GenreId = 3,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BN2NmMWYyNmQtNGExMy00NmEwLTk3NDMtYjdlMGE5YmNjYmI3XkEyXkFqcGdeQXVyNzQxNDExNTU@._V1_QL75_UY281_CR10", "Caught in the Rain", 3)
            },
            new Movie
            {
                Title = "Dough and Dynamite",
                Description = "Dough and Dynamite is a hilarious comedy film that explores the misadventures of two bakers. Join them in their flour-filled antics.",
                ReleaseDate = new DateTime(1914, 1, 7),
                Rating = 3,
                GenreId = 3,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZTAxY2JiODgtZmZiMC00ODk0LWJhYWQtYTMyNDUwMWFkYWE2XkEyXkFqcGdeQXVyNzQxNDExNTU@._V1_QL75_UX190_CR0", "Dough and Dynamite", 3)
            },
            new Movie
            {
                Title = "Gentlemen of Nerve",
                Description = "Gentlemen of Nerve is a comedy film that takes you on a ride of laughter and fun as the characters embark on amusing adventures.",
                ReleaseDate = new DateTime(1914, 2, 9),
                Rating = 4,
                GenreId = 3,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BNzNhODg3ZmMtYTcwYi00ZmU1LTg4ZWEtZmUxNWNlMmI4MjAyXkEyXkFqcGdeQXVyNzQxNDExNTU@._V1_QL75_UY281_CR10", "Gentlemen of Nerve", 3)
            },
            new Movie
            {
                Title = "Getting Acquainted",
                Description = "Getting Acquainted is a comedy film that showcases humorous interactions between characters. Join them as they navigate funny situations.",
                ReleaseDate = new DateTime(1914, 6, 8),
                Rating = 3,
                GenreId = 3,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMmU2ZmEyNjEtMDQ1Ni00ZmUzLWIzZGEtNzU2NTYwY2IyOWVlXkEyXkFqcGdeQXVyMTE4NTI5NTA@._V1_QL75_UY281_CR14", "Getting Acquainted", 3)
            },
            new Movie
            {
                Title = "The Knockout",
                Description = "The Knockout is a comedy film that delivers punch after punch of humor. Join the laughter and the knockout comedy in this film.",
                ReleaseDate = new DateTime(1914, 7, 11),
                Rating = 4,
                GenreId = 3,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BNGIxNjc4YjgtZDdlYy00ZWVmLTllZjAtZWYwMTUxZDJmNTA2XkEyXkFqcGdeQXVyNzYzMTI4ODE@._V1_UX256", "The Knockout", 3)
            },
            new Movie
            {
                Title = "Mabel at the Wheel",
                Description = "Mabel at the Wheel is a comedy film that revolves around Mabel's amusing adventures on the road. Buckle up for a hilarious ride.",
                ReleaseDate = new DateTime(1914, 12, 7),
                Rating = 3,
                GenreId = 3,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BNzI5MDUzZmMtMjVjNC00Mjc3LThmYmQtNmRhYzg4MGMzYjA3XkEyXkFqcGdeQXVyNjA5MTAzODY@._V1_QL75_UX190_CR0", "Mabel at the Wheel", 3)
            },
            new Movie
            {
                Title = "Mabel's Blunder",
                Description = "Mabel's Blunder is a comedy film filled with hilarious mishaps. Join Mabel as she stumbles through comical predicaments.",
                ReleaseDate = new DateTime(1914, 9, 18),
                Rating = 4,
                GenreId = 3,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMjIwNTM1NTg2M15BMl5BanBnXkFtZTcwMTE3NzQyMw@@._V1_QL75_UY281_CR46", "Mabel's Blunder", 3)
            },
            new Movie
            {
                Title = "Mabel's Married Life",
                Description = "Mabel's Married Life is a comedy film that humorously explores the ups and downs of married life. Expect laughter and love.",
                ReleaseDate = new DateTime(1914, 12, 2),
                Rating = 3,
                GenreId = 3,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BOTYxZDUxOWQtOGJmZS00YTg1LTgxMjEtZTI5ZDA2ZmFlYjU4XkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_QL75_UX190_CR0", "Mabel's Married Life", 3)
            },
            new Movie
            {
                Title = "Mabel's Strange Predicament",
                Description = "Mabel's Strange Predicament is a comedy film that takes you on a strange and funny journey with Mabel. Expect the unexpected!",
                ReleaseDate = new DateTime(1914, 2, 9),
                Rating = 4,
                GenreId = 3,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BODBjMzVjNjAtYmVmOS00MGNlLTgyOTEtNzFhYzlkNzNjNDNjXkEyXkFqcGdeQXVyNzU3NTk0NjA@._V1_QL75_UX190_CR0", "Mabel's Strange Predicament", 3)
            },
            new Movie
            {
                Title = "Making a Living",
                Description = "Making a Living is a comedy film that explores the humorous side of making a living. Join the characters as they chase success with laughs.",
                ReleaseDate = new DateTime(1914, 2, 2),
                Rating = 3,
                GenreId = 3,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BYWEyZDY4MzQtMzllOS00MDY0LWE5M2YtY2YzOWI3ZWEzZDliXkEyXkFqcGdeQXVyNjY0ODg0MTA@._V1_QL75_UX190_CR0", "Making a Living", 3)
            },
            new Movie
            {
                Title = "The Masquerader",
                Description = "The Masquerader is a comedy film that unfolds the comedic events of a masquerade party. Prepare for disguises, humor, and surprises.",
                ReleaseDate = new DateTime(1914, 10, 27),
                Rating = 4,
                GenreId = 3,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BN2Y1OTY1YTktMjYzZC00MGZlLWI3YmItYTJkZGIzMzE0ZTljL2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyMjUxODE0MDY@._V1_QL75_UX190_CR0", "The Masquerader", 3)
            },
            new Movie
            {
                Title = "The New Janitor",
                Description = "The New Janitor is a comedy film that showcases the humorous challenges faced by a new janitor. Get ready for a clean dose of laughter.",
                ReleaseDate = new DateTime(1914, 8, 21),
                Rating = 3,
                GenreId = 3,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BNjZkYjA0NTEtOWJhNS00MmY0LTlhYjUtMzg2MzNmMTE3NDJjXkEyXkFqcGdeQXVyNzQxNDExNTU@._V1_QL75_UY281_CR10", "The New Janitor", 3)
            },
            //seed drama movies with an id of 4
            
            new Movie
            {
                Title = "The Adventures of Dollie",
                Description = "The Adventures of Dollie is a heartwarming drama about a young girl's journey filled with curiosity and discovery.",
                ReleaseDate = new DateTime(1908, 7, 14),
                Rating = 4,
                GenreId = 4,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMDlmYzgwZmItNzdlMS00ZmE5LThkYmUtYmNhNjAyY2FlMmFiXkEyXkFqcGdeQXVyMTYxNjkxOQ@@._V1_QL75_UY281_CR6", "The Adventures of Dollie", 4)
            },
            new Movie
            {
                Title = "The Black Viper",
                Description = "The Black Viper is a thrilling drama that delves into the world of espionage and danger as spies uncover a sinister plot.",
                ReleaseDate = new DateTime(1908, 12, 12),
                Rating = 4,
                GenreId = 4,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZDVjYTU4ZmYtN2JiZi00OGM3LWE2ZWMtNmYyNGViNmI4NDEzXkEyXkFqcGdeQXVyNzU3NjUzNTc@._V1_QL75_UX190_CR0", "The Black Viper", 4)
            },
            new Movie
            {
                Title = "At the Altar",
                Description = "At the Altar is a touching drama that explores love, sacrifice, and the emotional journey of a bride and groom.",
                ReleaseDate = new DateTime(1909, 2, 7),
                Rating = 3,
                GenreId = 4,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BOTMxMzQwNjEtYjQ0Yy00Mjk1LWE2MWItNjYwY2NhY2I3OWQwXkEyXkFqcGdeQXVyMzc1NTUwNjM@._V1_QL75_UY281_CR90", "At the Altar", 4)
            },
            new Movie
            {
                Title = "A Drunkard's Reformation",
                Description = "A Drunkard's Reformation is a powerful drama that portrays the redemption and transformation of a man struggling with addiction.",
                ReleaseDate = new DateTime(1909, 3, 6),
                Rating = 4,
                GenreId = 4,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BODIwNTAyZTktZjVhMi00NTA3LWJjMTQtNTQ0NzUzZDEwMzM2XkEyXkFqcGdeQXVyMzc1NTUwNjM@._V1_QL75_UY281_CR90", "A Drunkard's Reformation", 4)
            },


            new Movie
            {
                Title = "A Lad from Old Ireland",
                Description = "A Lad from Old Ireland is a touching drama that follows the story of an Irish immigrant and his journey to a new land.",
                ReleaseDate = new DateTime(1910, 9, 21),
                Rating = 4,
                GenreId = 4,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BOTc3NTA3YTItYzJkNC00MzY0LTlhOWMtODk4MDJlMGY2ZmRlXkEyXkFqcGdeQXVyMDM0MzU2NA@@._V1_QL75_UY281_CR3", "A Lad from Old Ireland", 4)
            },
            new Movie
            {
                Title = "The Black Arrow: A Tale of the Two Roses",
                Description = "The Black Arrow: A Tale of the Two Roses is an exciting drama set in the backdrop of the Wars of the Roses.",
                ReleaseDate = new DateTime(1911, 4, 29),
                Rating = 4,
                GenreId = 4,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BOTIxYTM0YTUtYjQ5NS00NDZjLWEwMTgtYmMyYTk5YWJlNzE2XkEyXkFqcGdeQXVyNzA4ODc3ODU@._V1_QL75_UY281_CR3", "The Black Arrow: A Tale of the Two Roses", 4)
            },
            new Movie
            {
                Title = "Brown of Harvard",
                Description = "Brown of Harvard is a drama that portrays the life of a young man as he navigates the challenges and experiences of college.",
                ReleaseDate = new DateTime(1911, 8, 1),
                Rating = 4,
                GenreId = 4,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMTYxMDgwMDY1OV5BMl5BanBnXkFtZTgwMjk0NDIwMjE@._V1_QL75_UX190_CR0", "Brown of Harvard", 4)
            },
                        new Movie
            {
                Title = "The Musketeers of Pig Alley",
                Description = "The Musketeers of Pig Alley is a gripping drama that takes you into the heart of the city's underworld.",
                ReleaseDate = new DateTime(1912, 3, 12),
                Rating = 4,
                GenreId = 4,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMTkyNzk5MDYzOV5BMl5BanBnXkFtZTgwNzQ3Njk5MTE@._V1_QL75_UX190_CR0", "The Musketeers of Pig Alley", 4)
            },
            new Movie
            {
                Title = "Put Yourself in His Place",
                Description = "Put Yourself in His Place is an intense drama that explores the complexities of human relationships and emotions.",
                ReleaseDate = new DateTime(1912, 12, 30),
                Rating = 4,
                GenreId = 4,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BYjU4OTE2ZDEtYjFkYi00MzY4LWFjMDYtMWE4MjliMjI0YWY4XkEyXkFqcGdeQXVyMDUyOTUyNQ@@._V1_QL75_UX190_CR0", "Put Yourself in His Place", 4)
            },
            new Movie
            {
                Title = "The Quakeress",
                Description = "The Quakeress is a heartwarming drama that tells the story of love and faith in the face of adversity.",
                ReleaseDate = new DateTime(1913, 7, 27),
                Rating = 4,
                GenreId = 4,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZThhZDAzMmUtMTRlYi00NzI1LWIxMDktM2Y3MzYyYTE3MmRlXkEyXkFqcGdeQXVyMDUyOTUyNQ@@._V1_QL75_UY281_CR89", "The Quakeress", 4)
            },
            new Movie
            {
                Title = "The Restless Spirit",
                Description = "The Restless Spirit is a drama that delves into the human psyche and the pursuit of inner peace.",
                ReleaseDate = new DateTime(1913, 11, 9),
                Rating = 4,
                GenreId = 4,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMTc1NDI4MTQ1NF5BMl5BanBnXkFtZTcwNzQzNzkxMQ@@._V1_QL75_UY281_CR3", "The Restless Spirit", 4)
            },
            new Movie
            {
                Title = "The Telephone Girl and the Lady",
                Description = "The Telephone Girl and the Lady is an enthralling drama that explores the contrasting lives of two women in society.",
                ReleaseDate = new DateTime(1913, 12, 14),
                Rating = 4,
                GenreId = 4,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BNThmNTQwZTMtYzc0ZS00MWM2LWI3YjYtNDA5ZGY1OTU2MTFhXkEyXkFqcGdeQXVyMjUxODE0MDY@._V1_QL75_UY281_CR155", "The Telephone Girl and the Lady", 4)
            },
            new Movie
            {
                Title = "The Escape",
                Description = "The Escape is a thrilling drama that takes you on a journey of suspense and survival.",
                ReleaseDate = new DateTime(1913, 12, 10),
                Rating = 4,
                GenreId = 4,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZjYxMjdhZTAtZmUwYS00MDI2LWE1MTAtODU2ZTVhM2RkOTcxXkEyXkFqcGdeQXVyNzM4MjE4NjQ@._V1_UX256", "The Escape", 4)
            },

            //seed thriller movies with genre id of 5
                        new Movie
            {
                Title = "A Blind Bargain",
                Description = "A Blind Bargain is a thrilling silent film.",
                ReleaseDate = new DateTime(1922, 8, 15),
                Rating = 4,
                GenreId = 5,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BNzM4MjRjMDYtN2E0Mi00ZDlmLWJmZGYtNTE5ZjE5YzY4N2FjXkEyXkFqcGdeQXVyMjUxODE0MDY@._V1_QL75_UX190_CR0", "A Blind Bargain", 5)
            },
            //new Movie
            //{
            //    Title = "The Mystic",
            //    Description = "The Mystic is a suspenseful thriller that will keep you on the edge of your seat.",
            //    ReleaseDate = new DateTime(1925, 11, 23),
            //    Rating = 3,
            //    GenreId = 5,
            //    PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZWYyNDMwYWMtYjhlMS00ODdiLWIxZjItNWE0YzAxMGYxZGZmXkEyXkFqcGdeQXVyNDM0MjExOA@@._V1_QL75_UY281_CR2", "The Mystic", 5)
            //},
            new Movie
            {
                Title = "Phantom of the Opera",
                Description = "Phantom of the Opera is a classic thriller featuring the iconic character.",
                ReleaseDate = new DateTime(1925, 9, 6),
                Rating = 5,
                GenreId = 5,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BNDIwODc1MzQwM15BMl5BanBnXkFtZTgwODQ5NzU4NzE@._V1_UX256", "Phantom of the Opera", 5)
            },
            new Movie
            {
                Title = "Wolf Blood",
                Description = "Wolf Blood is a suspenseful thriller where a man is transformed into a werewolf.",
                ReleaseDate = new DateTime(1925, 10, 19),
                Rating = 3,
                GenreId = 5,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BN2YxYjc0ZWYtYzE5Yy00NmViLTlhNDktZWFjODg0YmYyYTZiL2ltYWdlXkEyXkFqcGdeQXVyNDM1NjcwNw@@._V1_QL75_UY281_CR5", "Wolf Blood", 5)
            },
            new Movie
            {
                Title = "The Magician",
                Description = "The Magician is a thrilling film where a magician's secrets are unveiled.",
                ReleaseDate = new DateTime(1926, 12, 18),
                Rating = 4,
                GenreId = 5,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZTZkOTdmM2QtOGFlNC00MjdmLWE0NWEtNzY0ZDk2ZmIwY2EyXkEyXkFqcGdeQXVyNTM3NzExMDQ@._V1_UX256", "The Magician", 5)
            },
            new Movie
            {
                Title = "London After Midnight",
                Description = "London After Midnight is a classic thriller known for its eerie atmosphere.",
                ReleaseDate = new DateTime(1927, 12, 4),
                Rating = 5,
                GenreId = 5,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZDM0YmVjMWQtNTEwZC00YzY3LWJkMWMtNTg3MDVlMzRjZWUzXkEyXkFqcGdeQXVyMDI2NDg0NQ@@._V1_QL75_UX190_CR0", "London After Midnight", 5)
            },
            new Movie
            {
                Title = "Seven Footprints to Satan",
                Description = "Seven Footprints to Satan is a suspenseful thriller with a captivating storyline.",
                ReleaseDate = new DateTime(1929, 2, 15),
                Rating = 4,
                GenreId = 5,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMjA0NzU5NTQwOV5BMl5BanBnXkFtZTgwNDEwMTgxMjE@._V1_QL75_UX190_CR0", "Seven Footprints to Satan", 5)
            },
            new Movie
            {
                Title = "Safe in Hell",
                Description = "Safe in Hell is a thrilling film that will keep you guessing until the end.",
                ReleaseDate = new DateTime(1931, 5, 31),
                Rating = 3,
                GenreId = 5,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMjI3MDE4Mjk4OV5BMl5BanBnXkFtZTgwMzI5Njc0MjE@._V1_QL75_UY281_CR3", "Safe in Hell", 5)
            },
            new Movie
            {
                Title = "Almost Married",
                Description = "Almost Married is a suspenseful thriller with unexpected twists and turns.",
                ReleaseDate = new DateTime(1932, 6, 5),
                Rating = 2,
                GenreId = 5,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMjA3MjMyMzc3MF5BMl5BanBnXkFtZTgwMjE4OTg4MTE@._V1_QL75_UX190_CR0", "Almost Married", 5)
            },

            new Movie
            {
                Title = "Murders in the Zoo",
                Description = "Murders in the Zoo is a thrilling film set in a zoo with dark secrets.",
                ReleaseDate = new DateTime(1933, 12, 22),
                Rating = 4,
                GenreId = 5,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BODU5MGE3ZDMtZDQ2ZS00OGU4LWFiYzAtMDA1Y2YzZTI3MmZmXkEyXkFqcGdeQXVyMTQ2MjQyNDc@._V1_QL75_UY281_CR1", "Murders in the Zoo", 5)
            },

            new Movie
            {
                Title = "Night of Terror",
                Description = "Night of Terror is a thrilling film filled with suspense and terror.",
                ReleaseDate = new DateTime(1933, 11, 17),
                Rating = 3,
                GenreId = 5,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMTIwODU2MzQ2NV5BMl5BanBnXkFtZTcwNTU4MjE2MQ@@._V1_QL75_UY281_CR46", "Night of Terror", 5)
            },
            new Movie
            {
                Title = "Supernatural",
                Description = "Supernatural is a suspenseful thriller with elements of the supernatural.",
                ReleaseDate = new DateTime(1933, 12, 14),
                Rating = 4,
                GenreId = 5,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BODYyMGJiMGUtZGZiYS00MDk2LTgwMGEtYzBjNjQ4ZGMzMzZjXkEyXkFqcGdeQXVyMzU0NzkwMDg@._V1_UX256", "Supernatural", 5)
            },
            new Movie
            {
                Title = "The Crime of Dr. Crespi",
                Description = "The Crime of Dr. Crespi is a thrilling film with a mysterious doctor.",
                ReleaseDate = new DateTime(1935, 5, 25),
                Rating = 5,
                GenreId = 5,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BMTY5MTg3MTM2M15BMl5BanBnXkFtZTcwMDk0OTcyMQ@@._V1_QL75_UX190_CR0", "The Crime of Dr. Crespi", 5)
            },
            new Movie
            {
                Title = "Mystery Woman",
                Description = "Mystery Woman is a suspenseful thriller with an enigmatic female lead.",
                ReleaseDate = new DateTime(1935, 2, 24),
                Rating = 4,
                GenreId = 5,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BYWFjOTMyOTQtOTg1YS00MGI2LWE4YWItYWVjOTNlYTNjMjgyXkEyXkFqcGdeQXVyMTk0MjQ3Nzk@._V1_QL75_UY281_CR6", "Mystery Woman", 5)
            },

            new Movie
            {
                Title = "The Ape",
                Description = "The Ape is a suspenseful thriller with mysterious occurrences.",
                ReleaseDate = new DateTime(1940, 6, 28),
                Rating = 3,
                GenreId = 5,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BNTkyNDIwZWUtNjI4OS00YjAyLWIyMmYtZDQ5MWQxMmY2ZmU2XkEyXkFqcGdeQXVyMTQ2MjQyNDc@._V1_QL75_UX190_CR0", "The Ape", 5)
            },

            new Movie
            {
                Title = "The Devil Commands",
                Description = "The Devil Commands is a thriller with a scientist seeking answers from the beyond.",
                ReleaseDate = new DateTime(1941, 12, 13),
                Rating = 4,
                GenreId = 5,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BOTA4YTE2OTUtZWU3Zi00ZjQzLWI1MGYtNmE3ZDEyNzllNWUyL2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyNjEwMTA0NTc@._V1_QL75_UX190_CR0", "The Devil Commands", 5)
            },

            new Movie
            {
                Title = "Man Hunt",
                Description = "Man Hunt is a suspenseful thriller about a man on the run.",
                ReleaseDate = new DateTime(1941, 6, 13),
                Rating = 4,
                GenreId = 5,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZDVkYmY1ZjgtZWRhZC00YjcxLTg1NjItMDVjMTRjM2Q1MWQ5XkEyXkFqcGdeQXVyMDY4MzkyNw@@._V1_QL75_UX190_CR0", "Man Hunt", 5)
            },
            new Movie
            {
                Title = "Man Made Monster",
                Description = "Man Made Monster is a thrilling tale of a man turned into a monster.",
                ReleaseDate = new DateTime(1941, 3, 28),
                Rating = 5,
                GenreId = 5,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BNzU1NTcxMGEtYzdjYy00NDU2LWE2NzgtODMxN2YxZWI1MGNjXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_QL75_UX190_CR0", "Man Made Monster", 5)
            },
            new Movie
            {
                Title = "The Monster and the Girl",
                Description = "The Monster and the Girl is a thrilling film about a man and his monstrous creation.",
                ReleaseDate = new DateTime(1941, 12, 25),
                Rating = 4,
                GenreId = 5,
                PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BZDE4MmIwYjEtYmE1Zi00MThkLTgyYjctYTJjZWJiMDQ3ZWUxXkEyXkFqcGdeQXVyMzUzNTU3Mw@@._V1_QL75_UX190_CR0", "The Monster and the Girl", 5)
            },
            //new Movie
            //{
            //    Title = "Rage in Heaven",
            //    Description = "Rage in Heaven is a suspenseful thriller with themes of obsession and jealousy.",
            //    ReleaseDate = new DateTime(1941, 9, 12),
            //    Rating = 3,
            //    GenreId = 5,
            //    PhotoUrl = await DownloadImg("https://m.media-amazon.com/images/M/MV5BYjA1NWMzYmUtNDk2OS00NzE0LWI3YjMtYjg3MWYzMTY5MzkxXkEyXkFqcGdeQXVyMTk2MzI2Ng@@._V1_QL75_UX190_CR0", "Rage in Heaven", 5)
            //}

            };





                _context.Movies.AddRange(movies);
                await _context.SaveChangesAsync();
            }
        }

        private async Task<string> DownloadImg(string url, string title, int genreId)
        {
            try
            {
                // Download the image from the URL
                using var client = new HttpClient();
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var imageBytes = await response.Content.ReadAsByteArrayAsync();

                // Convert the image to an IFormFile
                using var imageStream = new MemoryStream(imageBytes);
                var imageFile = new FormFile(imageStream, 0, imageBytes.Length, null, Path.GetFileName(url));

                // Upload the image file
                var uploadResult = await _cloudinaryService.UploadMovieImageAsync(imageFile, title, genreId);
                return uploadResult.Uri.ToString();
            }
            catch (Exception ex)
            {

                return "https://res.cloudinary.com/dhdlvnrup/image/upload/v1771017601/samples/ChatGPT_Image_Feb_13_2026_11_17_58_PM_zaqrme.png";
            }

        }
    }
}
