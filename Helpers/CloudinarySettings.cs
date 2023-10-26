using Microsoft.Extensions.Configuration;

namespace Movies.Helpers
{
    public class CloudinarySettings
    {

        private static IConfiguration _configuration;

        public static string CloudName { get; private set; }
        public static string ApiKey { get; private set; }
        public static string ApiSecret { get; private set; }

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;

            // Set the read-only properties
            CloudName = _configuration.GetSection("CloudinarySettings:CloudName").Value;
            ApiKey = _configuration.GetSection("CloudinarySettings:ApiKey").Value;
            ApiSecret = _configuration.GetSection("CloudinarySettings:ApiSecret").Value;
        }

    }
}
