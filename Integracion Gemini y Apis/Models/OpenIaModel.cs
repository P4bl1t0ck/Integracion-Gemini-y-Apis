using Newtonsoft.Json;

namespace Integracion_Gemini_y_Apis.Models
{
    /// <summary>
    /// How this Json will look like:
    ///   {
    ///   "model":"gpt-3.5-turbo", //Request
    ///   "messages":[             //Message
    ///     { "role": "usuarior","content":"Hola,¿cómo estás?"} //Atributos de la clase Message
    ///   ],
    ///   "temperature":0.7
    ///   }
    /// </summary>
   

    public class OpenAIRequest
    {
        [JsonProperty("model")]
        public string Model { get; set; } = "gpt-3.5-turbo";

        [JsonProperty("messages")]
        public List<Message> Messages { get; set; }

        [JsonProperty("temperature")]
        public double Temperature { get; set; } = 0.7;
    }

    public class Message
    {
        [JsonProperty("role")]
        public string Role { get; set; } // "user", "assistant", "system"

        [JsonProperty("content")]
        public string Content { get; set; }
    }
    /// <summary>
    /// {
    /// "Choice":[{"Message":"Bien y tu ?"}]
    /// }
    /// </summary>
    //Por lo que entiendo.
    public class OpenAIResponse
    {
        [JsonProperty("choices")]
        public List<Choice> Choices { get; set; }
    }

    public class Choice
    {
        [JsonProperty("message")]
        public Message Message { get; set; }
    }
}
