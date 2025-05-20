using System.Net.Http.Headers;
using System.Text;
using Integracion_Gemini_y_Apis.Interface;
using Integracion_Gemini_y_Apis.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        
        }

        public async Task<string> GetChatBotResponse(string prompt)
        {
                //Veamos si esto funciona le hare una prueba si no me da error.
                string url_huggings = "https://api-inference.huggingface.co/models/gpt2";
            //Esta es la url de la api de Hugging Face, la cual me da el modelo de gpt2.
            //El Json que debe de funfionar



            HuggingRequest request = new HuggingRequest
            {
                inputs = prompt,
                parameters = new Parameters
                {
                    MaxNewTokens = 50,
                    Temperature = 0.7
                }
            };
                string requestJson = JsonConvert.SerializeObject(request);
                Console.WriteLine("Json enviado a Huggin Face: \n" + requestJson);
                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
                //Le pasamos el json a la variable content.

                var response = await _httpClient.PostAsync(url_huggings, content);
                //Le pasamos la respuesta a la variable response.
                //Y la hacemos asincornica para que no se cuelge el programa

                var answer = await response.Content.ReadAsStringAsync();

            //La respuesta de el gpt2, lan recibimos dentro de la variable answer y dentro de
            //la variable jsonArray, la cual es un array de la clase HugginResponse.
            //Accedfe a la respuesta generada por el modelo.
            if (!answer.TrimStart().StartsWith("["))
            {
                Console.WriteLine("Respuesta cruda de la API:");
                Console.WriteLine(answer);
                throw new Exception("La respuesta de la API no tiene formato JSON válido.");
            }
            
            var jsonArray = JsonConvert.DeserializeObject<List<HugginResponse>>(answer);
            return jsonArray[0].Generatedtext;
        }

        public Task<bool> SaveResponse(string chatbotprompt, string response)
        {
            //Este metodo me debo de encargar para el contexto de base de datos.
            throw new NotImplementedException();
        }
    }
}
