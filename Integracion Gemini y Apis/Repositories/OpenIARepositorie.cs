using Integracion_Gemini_y_Apis.Interface;
using Integracion_Gemini_y_Apis.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using static Integracion_Gemini_y_Apis.Models.OpenIAModels;

namespace Integracion_Gemini_y_Apis.Repositories
{
    public class OpenAIRepositorie : IChatbotServive
    {
        private readonly HttpClient _httpClient;

        public OpenAIRepositorie()
        {
            _httpClient = new HttpClient();

            // 🔹 Leer la variable de entorno
            string? token = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("❌ Token de OpenAI no encontrado. Asegúrate de configurar la variable de entorno 'OPENAI_API_KEY'.");
            }

            // 🔹 Configurar el header Authorization
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Console.WriteLine("Token cargado: " + token); // Solo para probar, luego elimínalo por seguridad.

        }

        public async Task<string> GetChatBotResponse(string prompt)
        {
            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                max_tokens = 100,
                temperature = 0.7,
                messages = new[]
                {
                    new { role = "user", content = prompt }
                }
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var responseJson = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"❌ Error desde OpenAI: {response.StatusCode} - {responseJson}");
            }

            var aiResponse = JsonConvert.DeserializeObject<OpenAIResponse>(responseJson);
            return aiResponse.Choices[0].Message.Content.Trim();
        }

        public Task<bool> SaveResponse(string chatbotprompt, string response)
        {
            throw new NotImplementedException();
        }
    }
}
