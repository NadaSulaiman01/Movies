namespace Movies.Seeds
{
    public class DefaultRoles
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {




            /*if there is no role in the database, 
             * do the following actions.
             */
            if (!roleManager.Roles.Any())
            {
                /*as the method is async so await is needed*/
                await roleManager.CreateAsync(new IdentityRole(AppRolesConstants.Admin));
                await roleManager.CreateAsync(new IdentityRole(AppRolesConstants.User));

            }
        }
    }
}
