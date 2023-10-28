using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Movies.DTOs.AuthDTOs;
using Movies.Seeds;
using Movies.Services.Auth_Service;
using Movies.Services.Cloudinary_Service;
using Movies.Validators.Auth_Validators;
using Swashbuckle.AspNetCore.Filters;


var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();

//Add validators
builder.Services.AddTransient<IValidator<LoginRequestDTO>, LoginValidator>();


//Connect to database
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
    o =>
    {
        // configure identity options
        o.User.RequireUniqueEmail = true;
        o.Password.RequireDigit = false;
        o.Password.RequireLowercase = false;
        o.Password.RequireUppercase = false;
        o.Password.RequireNonAlphanumeric = false;
        o.Password.RequiredLength = 6;
    }
    )
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true


    };

});


builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization using the bearer scheme, e.g. \"bearer {token} \"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.OperationFilter<SecurityRequirementsOperationFilter>();
});





var app = builder.Build();

CloudinarySettings.Initialize(builder.Configuration);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

using var scope = scopeFactory.CreateScope();





var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
var cloudinaryService = scope.ServiceProvider.GetRequiredService<ICloudinaryService>();
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

/*add roles to the database if not created*/
await DefaultRoles.SeedRolesAsync(roleManager);

//add genres to database if not added
await DefaultGenres.SeedGenresAsync(dbContext);

//add movies to database if not added
var defaultMovies = new DefaultMovies(cloudinaryService, dbContext);
await defaultMovies.SeedMoviesAsync();

//add movies to database if not added
var defaultCast = new DefaultCast(dbContext, cloudinaryService);
await defaultCast.SeedCastAsync();

var defaultActorsMovies = new DefaultActorMovie(dbContext);
await defaultActorsMovies.SeedActorMoviesAsync();

app.MapControllers();

app.Run();
