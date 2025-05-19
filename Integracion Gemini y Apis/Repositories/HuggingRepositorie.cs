using Integracion_Gemini_y_Apis.Interface;

namespace Integracion_Gemini_y_Apis.Repositories
{
    public class HuggingRepositorie : IChatbotServive
    {
        
        private HttpClient _httpClient;
        //Esto es por temas de seguridad , no se puede dejar el token en el codigo.
        //Para ingresar el token , se debe de crear una variable temporal en el cmd.
        //Le pasare al profesor la Api de Hugging Face para que la pruebe. Y  pueda crearla para que funcione el programa
        //Git no me dejaba el enviar los cambios

        string token = Environment.GetEnvironmentVariable("HUGGINGFACE_TOKEN");
        
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
