namespace Movies.Models
{
    public class ServiceResponseWithoutData
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }
}
