namespace Integracion_Gemini_y_Apis.Models
{
    public class GeminiModels
    {
        public class  GeminiRequest 
        {
            public List<Content> contents { get; set; }
        }
        public class GeminiContent
        {
            public List<GeminiRequest> parts { get; set; }
        }
        public class GeminiPart
        {
            public string text { get; set; }
        }
    }
}
