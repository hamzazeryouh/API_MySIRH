using System.ComponentModel.DataAnnotations;

namespace API_MySIRH.Entities
{
    public class Memo : EntityBase
    {
        public string Titre { get; set; } = String.Empty;
        
        [MaxLength] 
        public string HtmlContent { get; set; }= String.Empty;  
    }
}
