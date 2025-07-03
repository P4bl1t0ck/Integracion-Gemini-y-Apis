using Newtonsoft.Json;

namespace Integracion_Gemini_y_Apis.Models
{
    public class OpenIAModels
    {
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

        public class Message
        {
            [JsonProperty("role")]
            public string Role { get; set; }

            [JsonProperty("content")]
            public string Content { get; set; }
        }
    }
}
