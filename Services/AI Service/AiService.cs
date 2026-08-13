using OpenAI;
using OpenAI.Chat;
using System.ClientModel;

namespace Movies.Services.AI_Service
{
    public class AiService : IAiService
    {
        private readonly ChatClient _chatClient;
        public AiService()
        {  
            _chatClient  = new(
                model: AiSettings.ChatCompletetionsDeploymentName,
                credential: new ApiKeyCredential(AiSettings.ApiKey),
                options: new OpenAIClientOptions()
                {
                    Endpoint = new Uri($"{AiSettings.FoundryEndpoint}"),
                });
        }
        public async Task<string> SendMessageAsync(string message)
        {
            var messages = new List<ChatMessage>
            {
                new UserChatMessage(message)
            };

            ChatCompletion completion = await _chatClient.CompleteChatAsync(messages);

            return completion.Content[0].Text;
        }
    }
}
