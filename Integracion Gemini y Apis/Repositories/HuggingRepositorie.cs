using Integracion_Gemini_y_Apis.Interface;
using Integracion_Gemini_y_Apis.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace Integracion_Gemini_y_Apis.Repositories
{
    public class HuggingRepositorie : IChatbotServive
    {
        private  HttpClient _httpClient;
        private readonly HuggingsReponse_ContextoBaseDeDatos _contexto;
        private string token = "hf_Not_A_Api_Token";
        //Este token es un ejemplo, debes de sustituirlo por tu token de Hugging Face.
        //Cambie la token, debido a problemas de seguridad, ya que no me deja subirlo a Github.
        public HuggingRepositorie(HuggingsReponse_ContextoBaseDeDatos context)
        {
            _contexto = context;
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



        public async Task<bool> SaveResponse(string chatbotprompt, string response)
        {
            var entity = new HuggingResponseModel
            {
                response = response
                // Si quieres guardar el prompt, agrega una propiedad en el modelo y asígnala aquí.
            };

            _contexto.HuggingResponseModel.Add(entity);
            await _contexto.SaveChangesAsync();
            return true;
        }
    }
}
