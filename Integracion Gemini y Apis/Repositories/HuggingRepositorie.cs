using System.Text;
using Integracion_Gemini_y_Apis.Interface;
using Integracion_Gemini_y_Apis.Models;
using Newtonsoft.Json;

namespace Integracion_Gemini_y_Apis.Repositories
{
    public class HuggingRepositorie : IChatbotServive
    {
        
        private HttpClient _httpClient;
        //Esto es por temas de seguridad , no se puede dejar el token en el codigo.
        //Para ingresar el token , se debe de crear una variable temporal en el cmd.
        //Le pasare al profesor la Api de Hugging Face para que la pruebe. Y  pueda crearla para que funcione el programa
        //Git no me dejaba el enviar los cambios
        //Esta funcion la revise y consigue la varible de entorno de la computadora, la cual yo opte por hacerla 
        //en el cmd. Para que no se vea el token en el codigo. la pasare con el tiempo al profesor. (Estuve 1h20 para reparar este error. )
        //Console.WriteLine("Token de Hugging Face: " + token);
        public HuggingRepositorie()
        {
            _httpClient = new HttpClient();
            string token = Environment.GetEnvironmentVariable("HUGGINGFACE_TOKEN");
            if (string.IsNullOrEmpty(token))//In case it is null or empty or it doesn´t exist.
            {
                throw new Exception("Token de Hugging Face no encontrado. Asegúrate de haberlo configurado correctamente.");
            }

        }
        
        public async Task<string> GetChatBotResponse(string prompt)
        {
            //Veamos si esto funciona le hare una prueba si no me da error.
            string url_huggings = " https://api-inference.huggingface.co/models/gpt2";
            //Esta es la url de la api de Hugging Face, la cual me da el modelo de gpt2.
            HuggingPart huggingPart = new HuggingPart
            {
                text = prompt
            };

            //Llamamos a las listas para que tengan forma de json.
            string requestJson = JsonConvert.SerializeObject(huggingPart);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            //Le pasamos el json a la variable content.
            var response =await _httpClient.PostAsync(url_huggings, content);
            //Le pasamos la respuesta a la variable response.
            //Y la hacemos asincornica para que no se cuelge el programa
            var answer =await response.Content.ReadAsStringAsync();
            return answer;

            throw new NotImplementedException();
        }

        public Task<bool> SaveResponse(string chatbotprompt, string response)
        {
            //Este metodo me debo de encargar para el contexto de base de datos.
            throw new NotImplementedException();
        }
    }
}
