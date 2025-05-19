using System.Text;
using Integracion_Gemini_y_Apis.Interface;
using Integracion_Gemini_y_Apis.Models;
using Microsoft.Extensions.FileProviders.Composite;
using Newtonsoft.Json;


namespace Integracion_Gemini_y_Apis.Repositories
{
    public class GeminiRepositorie : IChatbotServive
    {
        private HttpClient _httpClient;
        private string geminiApiKey = "AIzaSyBZFA1dpLS1DejGK4otzvJCCmf1dgSn6SI";

        public GeminiRepositorie()
        {
            _httpClient = new HttpClient();
           
        }
        public async Task<string> GetChatBotResponse(string prompt)
        {
            //Como consigue la respuesta del chat de forma asincronica
            string url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=" + geminiApiKey;
            GeminiRequest request = new GeminiRequest
            {
                contents = new List<GeminiContent>
                {
                    new GeminiContent
                    {
                        parts = new List<GeminiPart>
                        {
                            new GeminiPart
                            {
                                text = prompt
                            }
                        }
                    }
                }
            };

            string requestJson = JsonConvert.SerializeObject(request);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url,content);
            var answer =await response.Content.ReadAsStringAsync();
            return answer;
        }   

        public Task<bool> SaveResponse(string chatbotprompt, string response)
        {
            //Este metodo me debo de encargar para el contexto de base de datos.
            throw new NotImplementedException();
        }
    }
}
