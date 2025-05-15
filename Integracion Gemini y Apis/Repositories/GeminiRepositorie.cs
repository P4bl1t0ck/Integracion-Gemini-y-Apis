using Integracion_Gemini_y_Apis.Interface;
using Integracion_Gemini_y_Apis.Models;
using Microsoft.Extensions.FileProviders.Composite;
using Newtonsoft.Json;

namespace Integracion_Gemini_y_Apis.Repositories
{
    public class GeminiRepositorie : IChatbotServive
    {
        private HttpClient _httpClient;
        private string geminiApiKey = "AIzaSyBZFA1dpLS1DejGK4otzvJCCmf1dgSn6SI"

        public GeminiRepositorie()
        {
            _httpClient = new HttpClient();
           
        }
        public Task<string> GetChatBotResponse(string prompt)
        {
            string url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=" + geminiApiKey;
            GeminiRequest request = new GeminiRequest
            {
                contents = new List<GeminiRepositorie>
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
            var content = new StringContent(requestJson, encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync(url,content);
        }
        public Task<bool> SaveResponse(string chatbotprompt, string response)
        {
            throw new NotImplementedException();
        }
    }
}
