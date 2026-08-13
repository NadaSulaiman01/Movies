namespace Movies.Helpers
{
    public class AiSettings
    {
        private static IConfiguration _configuration;
        public static string ChatCompletetionsDeploymentName { get; private set; }
        public static string FoundryEndpoint { get; private set; }
        public static string ApiKey { get; private set; }

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;

            // Set the read-only properties
            ChatCompletetionsDeploymentName = _configuration.GetSection("AiSettings:ChatCompletetionsDeploymentName").Value ?? "";
            FoundryEndpoint = _configuration.GetSection("AiSettings:FoundryEndpoint").Value ?? "";
            ApiKey = _configuration.GetSection("AiSettings:ApiKey").Value ?? "";
        }
    }
}
