using Integracion_Gemini_y_Apis.Interface;

namespace Integracion_Gemini_y_Apis.Repositories
{
    public class OpenAIRepositorie: IChatbotServive
    {
        public Task<string> GetChatBotResponse(string prompt)
        {
            throw new NotImplementedException();
        }
        public Task<bool> SaveResponse(string chatbotprompt, string response)
        {
            throw new NotImplementedException();
        }
    }
}
