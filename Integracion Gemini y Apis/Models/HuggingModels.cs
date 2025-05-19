namespace Integracion_Gemini_y_Apis.Models
{
    //Is the exact same as GeminiModels, but for the HuggingFace API
    public class HuggingRequest
    {
        public List<HuggingContent> contents { get; set; }
    }
    public class HuggingContent
    {
        public List<HuggingPart> parts { get; set; }
    }
    public class HuggingPart 
    {
        public string text { get; set; }
    }
}
