using API_MySIRH.Entities.MDM;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_MySIRH.Entities
{
    public class Candidat : EntityBase
    {
        public string? Nom { get; set; } 
        public string? Prenom { get; set; } 
        public DateTime? DateNaissance { get; set; }
        public string? Civilite { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public DateTime? DatePremiereExperience { get; set; }
        public DateTime? DateDeNaissance { get; set; }
        public decimal? SalaireActuel { get; set; }
        public decimal? PropositionSalariale{ get; set; }
        public string? ResidenceActuelle { get; set; }
        public string? EmploiEncore { get; set; }
        public int PosteId { get; set; }
        public Poste? Poste { get; set; }
        public int PosteNiveauId { get; set; }
        public PosteNiveau? Niveau { get; set; }
        public string? Commentaire { get; set; }

        public string? ImageUrl { get; set; }

        public string? CVUrl { get; set; }






    }
}
