namespace Movies.Seeds
{
    public class DefaultAppUsers
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private string adminPassword = string.Empty;
        private string userPassword = string.Empty;

        public DefaultAppUsers(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            adminPassword = _configuration.GetSection("Passwords:AdminPassword").Value;
            userPassword = _configuration.GetSection("Passwords:UserPassword").Value;
        }
        public async Task SeedAdminUserAsync()
        {
            ApplicationUser adminUser =
                new()
                {
                    Email = "admin@test.com",
                    UserName = "Admin",
                    EmailConfirmed = true,
                    Gender = "Male"
                };

            ApplicationUser normalUser =
                new()
                {
                    Email = "user@test.com",
                    UserName = "User",
                    EmailConfirmed = true,
                    Gender = "Male"
                };

            var admin = await _userManager.FindByEmailAsync(adminUser.Email);

            var user = await _userManager.FindByEmailAsync(normalUser.Email);

            if (admin is null)
            {

                await _userManager.CreateAsync(adminUser, adminPassword);
                await _userManager.AddToRoleAsync(adminUser, AppRolesConstants.Admin);
            }

            if (user is null)
            {
                await _userManager.CreateAsync(normalUser, userPassword);
                await _userManager.AddToRoleAsync(normalUser,AppRolesConstants.User);
            }
        }
    }
}
