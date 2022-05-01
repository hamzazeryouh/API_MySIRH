using API_MySIRH.Entities;
using System.ComponentModel.DataAnnotations;

namespace API_MySIRH.DTOs
{
    public class CommenterDTO:EntityBase
    {
        [Required(ErrorMessage = "le Commenter est obligatoire")]
        public string? Commente { get; set; }
    }
}
