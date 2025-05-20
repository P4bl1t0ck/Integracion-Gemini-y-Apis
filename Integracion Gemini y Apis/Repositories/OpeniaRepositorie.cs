using System.Net.Http.Headers;
using System.Text;
using Integracion_Gemini_y_Apis.Interface;
using Integracion_Gemini_y_Apis.Models;
using Newtonsoft.Json;

namespace Integracion_Gemini_y_Apis.Repositories
{
    public class OpeniaRepositorie : IChatbotServive
    {
        private HttpClient _httpClient;
        public OpeniaRepositorie()
        {
            _httpClient = new HttpClient();
            string token = Environment.GetEnvironmentVariable("OPENIA_TOKEN");//OPENIA_TOKEN
            Console.WriteLine("TOKEN CARGADO: " + token);
            if (string.IsNullOrEmpty(token))//In case it is null or empty or it doesn´t exist.
            {
                throw new Exception("Token de Open Ia no encontrado. Asegúrate de haberlo configurado correctamente.");
            }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<string> GetChatBotResponse(string prompt)
        {
            string url_openia = "https://api.openai.com/v1/chat/completions";
            //Esta es la url de la api de OpenIA, la cual me da el modelo de gpt3.5 turbo.
            var request = new OpenAIRequest
            {
                Messages = new List<Message>
                {
                    new Message { Role = "system", Content = "Eres un asistente útil." },
                     new Message { Role = "user", Content = prompt }
                }
            };
            //Nuestro fomrato de C# que tomaran forma de Json.
            string json = JsonConvert.SerializeObject(request);
            //Convertimos el objeto a Json.
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            //Es un json que se le pasa a la variable content.
            var response = await _httpClient.PostAsync(url_openia, content);
            //Es una respuesta asincronica.este se encarga de hacer la peticion a la api.
            var answer = await response.Content.ReadAsStringAsync();
            //Este toma la respuesta de la api y la lee de la forma asincronica.
            if (!response.IsSuccessStatusCode) 
            { 
                throw new Exception($"Error de OpenAI: {answer}");
            }
            var aiResponse = JsonConvert.DeserializeObject<OpenAIResponse>(answer);
            //Deserializamos la respuesta de la api a un objeto de la clase OpenAIResponse.
            return aiResponse.Choices[0].Message.Content.Trim();
            //La respuesta de el gpt3.5 turbo, lan recibimos dentro de la variable answer y dentro de
        }

        public Task<bool> SaveResponse(string chatbotprompt, string response)
        {
            throw new NotImplementedException();
        }
    }
}
