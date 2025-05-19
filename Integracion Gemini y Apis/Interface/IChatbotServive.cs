namespace Integracion_Gemini_y_Apis.Interface
{
    public interface IChatbotServive
    {
        Task<string> GetChatBotResponse(string prompt);
        //Consigue la respuesta del chat de forma asincronica
        Task<bool> SaveResponse(string chatbotprompt, string response);
        //Guarda la respuesta del chat de forma asincronica
        //Despues revisare como hacerlo para fguardarlo en una base de datos.
    }
}
