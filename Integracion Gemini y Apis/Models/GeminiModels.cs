namespace Integracion_Gemini_y_Apis.Models
{
   
        public class  GeminiRequest 
        {
            public List<GeminiContent> contents { get; set; }
        }
        public class GeminiContent
        {
            public List<GeminiPart> parts { get; set; }
        }
        public class GeminiPart
        {
            public string text { get; set; }
        }
    
}
 