namespace Integracion_Gemini_y_Apis.Interface
{
    public interface IChatbotServive
    {
        Task<string> GetChatBotResponse(string prompt);
        Task<bool> SaveResponse(string chatbotprompt, string response);
    }
}
