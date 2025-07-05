using System.ComponentModel.DataAnnotations;

namespace Integracion_Gemini_y_Apis.Models
{
    public class HuggingResponseModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(120)]// Assuming a maximum length for the responsE.
        //of course, depends of the API response size, but this is a good start.
        //Claro si el modelo quisiera responder -_-.
        public string? response { get; set; }

    }
}
