using API_MySIRH.Entities;
using System.ComponentModel.DataAnnotations;

namespace API_MySIRH.DTOs
{
    public class TemplateDTO:EntityBase
    {
        [Required(ErrorMessage = "le Technologie est obligatoire")]
        public string? Technologie { get; set; }
        [Required(ErrorMessage = "le Them est obligatoire")]
        public string? Them { get; set; }
        [Required(ErrorMessage = "le Title est obligatoire")]
        public string? Title { get; set; }

    }
}
