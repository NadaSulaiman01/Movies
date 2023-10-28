using Movies.Models;
using Movies.Services.Cloudinary_Service;

namespace Movies.Seeds
{
    public class DefaultCast
    {
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ApplicationDbContext _context;

        public DefaultCast(ApplicationDbContext context, ICloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
            _context = context;
        }

        public async Task SeedCastAsync()
        {
            if (!_context.Actors.Any())
            {
                string malePhoto = await DownloadImg("https://cdn2.iconfinder.com/data/icons/ios-7-icons/50/user_male-512.png", "Male", 100);
                string femalePhoto = await DownloadImg("https://cdn2.iconfinder.com/data/icons/ios-7-icons/50/user_female-512.png", "Female", 100);

                var cast = new List<Actor>
                {
                    //new Actor {
                    //    ActorName = "Sam Parker",
                    //    Gender = "Male",
                    //    PhotoUrl = malePhoto
                    //},
                    //new Actor {
                    //    ActorName = "Jessica Dragonette",
                    //    Gender = "Female",
                    //    PhotoUrl = femalePhoto
                    //}
                    new Actor
                    {
                        ActorName = "Sam Parker",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Jessica Dragonette",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Lanny Ross",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Pinto Colvig",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Jack Mercer",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Elmer Fudd",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Bugs Bunny",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tex Avery",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mel Blanc",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Bryan",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Cliff Edwards",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Dickie Jones",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Christian Rub",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Evelyn Venable",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Walter Catlett",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tex Avery",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mel Blanc",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Danny Webb",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tedd Pierce",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Bruce",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Sterling Holloway",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Edward Brophy",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Verna Felton",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Cliff Edwards",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Herman Bing",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Bugs Bunny",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tex Avery",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mel Blanc",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Kent Rogers",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tedd Pierce",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tex Avery",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mel Blanc",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Elmer Fudd",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Bryan",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Dick Nelson",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Jack Mercer",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tedd Pierce",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Pinto Colvig",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Carl Meyer",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Kate Wright",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Jack Mercer",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tedd Pierce",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Pinto Colvig",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Carl Meyer",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Kate Wright",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tex Avery",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Sara Berner",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mel Blanc",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Kent Rogers",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Martha Wentworth",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mel Blanc",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tex Avery",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Bruce",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tedd Pierce",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Dick Nelson",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mel Blanc",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tex Avery",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Kent Rogers",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Dick Nelson",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tedd Pierce",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mel Blanc",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tex Avery",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Kent Rogers",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Dick Nelson",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tedd Pierce",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mel Blanc",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tex Avery",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Kent Rogers",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Dick Nelson",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tedd Pierce",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mel Blanc",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tex Avery",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Robert Clampett",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Kent Rogers",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Cliff Nazarro",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Casper the Friendly Ghost",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Cecilia Loftus",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Frank Gallop",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Norma MacMillan",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Jack Mercer",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Porter",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Broncho Billy Anderson",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Barnes",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Walter Cameron",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Donald Gallaher",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Frank Lackteen",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mae Hotely",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Edgar Keller",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Tomlinson",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Guy Oliver",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Dorothy Phillips",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = " French",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Jack Mower",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Sydney Deane",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tom Santschi",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mary Pickford",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Jean Hersholt",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Gustav von Seyffertitz",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Anne Schaefer",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Roy Laidlaw",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Beatriz Michelena",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "House Peters",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Marc McDermott",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Thomas Carr",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "William Pike",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Theda Bara",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = " Lincoln",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Gaston Bese",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Alan Roscoe",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Gertrude Astor",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "John Wayne",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " the Horse",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Lee",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Grace Gordon",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Nelson McDowell",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tom Mix",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Art Acord",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Eva Novak",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = " the Horse",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Lockney",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Louise Lovely",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Earle Rodney",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Max Clifton",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Henry Herbert",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Gordon Begg",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Douglas Fairbanks",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Marjorie Daw",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Kathleen Kirkham",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Frank Campeau",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tully Marshall",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Douglas Fairbanks",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Bebe Daniels",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Edward Everett Horton",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Claud Allister",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Jack Mulhall",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Harry Carey",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Lee",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Ted Brooks",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Morris Foster",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Neva Gerber",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Douglas Fairbanks",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Marjorie Daw",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Frank Campeau",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Sam Fitz",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tully Marshall",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "John Wayne",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Lee",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Verna Hillie",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Monte Blue",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Hayes",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Marie Walcamp",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Harland Tucker",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Foster",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charlotte Burton",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Roy Watson",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Elmo Lincoln",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Enid Markey",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "True Boardman",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Kathleen Kirkham",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Thomas Jefferson",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Harry Carey",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Claire Adams",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Cullen Landis",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Myrtle Stedman",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Joe Harris",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mae Busch",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charley Chase",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Lucien Littlefield",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mabel Normand",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = " Tooker",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Barney Oldfield",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mabel Normand",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Ford Sterling",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Edward Arnold",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Ford Sterling",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mabel Normand",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Ford Sterling",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Avery",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Edgar Kennedy",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Hank Mann",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Ford Sterling",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Dorothy Kelly",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Gus Leonard",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Murray",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Louise Fazenda",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Chaplin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mack Swain",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Phyllis Allen",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charley Chase",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Harry McCoy",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Chaplin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Minta Durfee",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Edgar Kennedy",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Gordon Griffith",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Jess Dandy",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Chaplin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mack Swain",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Alice Davenport",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Alice Howell",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Helen Carruthers",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Chaplin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Chester Conklin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Fritz Schade",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Normand Denny",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Cecile Arnold",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Chaplin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mabel Normand",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Chester Conklin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Minta Durfee",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = " West",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Chaplin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Minta Durfee",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Phyllis Allen",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mack Swain",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charley Chase",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Fatty Arbuckle",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Minta Durfee",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = " Arbuckle",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Edgar Kennedy",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " John",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mabel Normand",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charlie Chaplin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Harry McCoy",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mack Sennett",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Alice Davenport",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mabel Normand",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Chaplin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Chester Conklin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Minta Durfee",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mack Swain",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mabel Normand",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Chaplin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mack Swain",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charley Chase",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Harry McCoy",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mabel Normand",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Chaplin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Chester Conklin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Alice Davenport",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charley Chase",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Chaplin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Henry Lehrman",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Virginia Kirtley",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Alice Davenport",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Chester Conklin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Chaplin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Arbuckle",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Chester Conklin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Minta Durfee",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Virginia Kirtley",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Chaplin",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mabel Normand",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Virginia Kirtley",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Alice Davenport",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mack Sennett",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Gladys Egan",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "William Bechtel",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " William Bechtel",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Gertrude McCoy",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "William Bechtel",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "William Garwood",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Violet Horner",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Clara Williams",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Henry King",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Frank Lloyd",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Florence Lawrence",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = " Johnson",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Linda Arvidson",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "George Gebhardt",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Edward Dillon",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Johnson",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Linda Arvidson",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "George Gebhardt",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Linda Arvidson",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = " Sullivan",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " McGowan",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Vignola",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mary Maurice",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Sidney Olcott",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Gene Gauntier",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Anna Rosemond",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Murdock MacQuarrie",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Leonard",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Owen Moore",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Thomas Santschi",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Jack Pickford",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mary Alden",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Louise Huff",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Ogle",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Farrell MacDonald",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Lillian Gish",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Elmer Booth",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Walter Miller",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Hill Mailes",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Clarine Seymour",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Lottie Briscoe",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Haley",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "William Courtright",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Harry McRae Webster",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Herbert Prior",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Florence Lawrence",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = " Johnson",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mary Pickford",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Owen Moore",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "David Miles",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Gail Kane",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Jane Miller",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Carlyle Blackwell",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Craig",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Florence Moore",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = " Warren Kerrigan",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Lois Wilson",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Beatrice Burnham",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "John Steppling",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Lillian Leighton",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mildred Harris",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Ward Crane",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Brown",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mae Gaston",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Francis McDonald",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Lon Chaney",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Raymond McKee",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Jacqueline Logan",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Ethel Grey Terry",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Virginia True Boardman",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Lon Chaney",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mary Philbin",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Norman Kerry",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Arthur Edmund Carewe",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Gibson Gowland",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "George Chesebro",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Marguerite Clayton",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Ray Hanford",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Milburn Morante",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Eugenie Besserer",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Alice Terry",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Paul Wegener",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "mier",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Gladys Hamer",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "thel",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Lon Chaney",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Marceline Day",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = " Walthall",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Percy Williams",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Conrad Nagel",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Thelma Todd",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Creighton Hale",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Sheldon Lewis",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Mong",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charles Gemora",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Dorothy Mackaill",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Donald Cook",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Ralf Harolde",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Morgan Wallace",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Nina Mae McKinney",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Richard Dix",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Vera Reynolds",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Monte Blue",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Arlette Marchal",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Dorothy Bracken",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Charlie Ruggles",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Lionel Atwill",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Lon Chaney Jr.",
                        Gender = "Male",
                        PhotoUrl = malePhoto

                    },
                    new Actor
                    {
                        ActorName = "Gail Patrick",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Randolph Scott",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Kathleen Burke",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Bela Lugosi",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Sally Blane",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Wallace Ford",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Tully Marshall",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Bryant Washburn",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Carole Lombard",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Randolph Scott",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Alan Dinehart",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = " Warner",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Vivienne Osborne",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Erich von Stroheim",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Lyle Talbot",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Paul Guilfoyle",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Dwight Frye",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Day",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Mona Maris",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Grant Withers",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Lucien Littlefield",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Warner Oland",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Anders Randolf",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Boris Karloff",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Maris Wrixon",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Donnell",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Dorothy Vaughan",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Gertrude Hoffman",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Boris Karloff",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Anne Revere",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Amanda Duff",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Richard Fiske",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Ralph Penney",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Walter Pidgeon",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Joan Bennett",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "George Sanders",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "John Carradine",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Roddy McDowall",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Lionel Atwill",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Anne Nagel",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = " Hinds",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Frank Albertson",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Ellen Drew",
                        Gender = "Female",
                        PhotoUrl = femalePhoto
                    },
                    new Actor
                    {
                        ActorName = "Robert Paige",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Paul Lukas",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Joseph Calleia",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    },
                    new Actor
                    {
                        ActorName = "Onslow Stevens",
                        Gender = "Male",
                        PhotoUrl = malePhoto
                    }
                };

                _context.Actors.AddRange(cast);
                await _context.SaveChangesAsync();
            }
        }

        private async Task<string> DownloadImg(string url, string title, int genreId)
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
    }
}
