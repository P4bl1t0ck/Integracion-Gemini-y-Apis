using Newtonsoft.Json;

namespace Integracion_Gemini_y_Apis.Models
{

    public class HuggingFaceResponse
    {
        /*Esta propiedad, indica con que parametro se ira el .json al ser convertida o desconvertida
         se escribiria solo la propiedad que aceptaria el modelo de gpt2 de hugging face.*/

        /*Ejmplo: {"generated_text":"Este es mi prompt"}
         Este valor de json tendra el valor de Este es mi prompt*/
        [JsonProperty("generated_text")]
        public string GeneratedText { get; set; }
        
    }
}
