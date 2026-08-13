namespace Movies.Services.AI_Service
{
    public interface IAiService
    {
        Task<string> SendMessageAsync(string message);
    }
}
