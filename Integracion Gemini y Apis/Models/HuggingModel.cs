using Newtonsoft.Json;

namespace Integracion_Gemini_y_Apis.Models
{

    public class HuggingFaceResponse
    {
        [JsonProperty("generated_text")]
        public string GeneratedText { get; set; }

    }
}
