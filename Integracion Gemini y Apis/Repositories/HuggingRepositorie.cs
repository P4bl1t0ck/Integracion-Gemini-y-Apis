using Integracion_Gemini_y_Apis.Interface;
using Integracion_Gemini_y_Apis.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Integracion_Gemini_y_Apis.Repositories
{
    public class HuggingRepositorie : IChatbotServive
    {
        private  HttpClient _httpClient;
        private string token = "hf_Oculto_Github_No_Me_Deja";
        public HuggingRepositorie()
        {
            _httpClient = new HttpClient();
            //string token = Environment.GetEnvironmentVariable("HF_TOKEN");//OPENIA_TOKEN
                    
            if (string.IsNullOrEmpty(token))//In case it is null or empty or it doesn´t exist.
            {
                throw new Exception("Token de Open Ia no encontrado. Asegúrate de haberlo configurado correctamente.");
            }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<string> GetChatBotResponse(string prompt)
        {
            string url = "https://api-inference.huggingface.co/models/google/gpt2";

            var requestBody = new
            {
                inputs = prompt
            };

            string requestJson = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            var answer = await response.Content.ReadAsStringAsync();
            return answer;
        }



        public Task<bool> SaveResponse(string chatbotprompt, string response)
        {
            throw new NotImplementedException();
        }
    }
}
