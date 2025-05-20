using Newtonsoft.Json;

namespace Integracion_Gemini_y_Apis.Models
{
    //It´s quite different to GeminiRepositorie
    public class HuggingRequest
    {
        //Esta clase principal con el mensaje de nuestro prompt
        [JsonProperty("inputs")]
        public string inputs { get; set; }
        //Esta clase define la configucación adicional de el tamaño de prompt y la temperatura.
        [JsonProperty("parameters")]
        public Parameters parameters { get; set; } = new Parameters();
    }
    public class Parameters
    {
        //Esta calse de parametros de nuestro objeto de  parametros nos funciona para
        //el modelo de Json.
        [JsonProperty("max_new_tokens")]
        public int MaxNewTokens { get; set; } = 50;
        [JsonProperty("temperature")]
        public double Temperature { get; set; } = 0.7;
    }
    //COmo el modelo actuara al recibir el prompt de el GPT2. de HUggings
    public class HugginResponse
    {
        [JsonProperty("generated_text")]
        //Este atributo que cuando lo recibe lo convierte en un Json.
        public string Generatedtext { get; set; }
    }
}
