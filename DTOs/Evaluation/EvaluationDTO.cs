using API_MySIRH.Entities;
using System.ComponentModel.DataAnnotations;

namespace API_MySIRH.DTOs
{
    public  class EvaluationDTO:EntityBase<int>
    {
        [Required(ErrorMessage = "le Evaluateur est obligatoire")]
        public string?  Evaluateur { get; set; }
        [Required(ErrorMessage = "le Date Entretien est obligatoire")]
        public DateTime? DateEntretien { get; set; }
        [Required(ErrorMessage = "le Candidat est obligatoire")]
        public int Candidat { get; set; }   
       public  int Commenters { get; set; }
        [Required(ErrorMessage = "le Template est obligatoire")]
        public int Template { get; set; }
    }
}
