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
        //Esta funcion la revise y consigue la varible de entorno de la computadora, la cual yo opte por hacerla 
        //en el cmd. Para que no se vea el token en el codigo. la pasare con el tiempo al profesor. (Estuve 1h20 para reparar este error. )

        public HuggingRepositorie()
        {
            _httpClient = new HttpClient();
            //

        }

        public Task<string> GetChatBotResponse(string prompt)
        {
            //Veamos si esto funciona le hare una prueba si no me da error.
            string fuente = " https://huggingface.co/settings/tokens" + token;
            throw new NotImplementedException();
        }

        public Task<bool> SaveResponse(string chatbotprompt, string response)
        {
            throw new NotImplementedException();
        }
    }
}
