using System.ComponentModel.DataAnnotations;

namespace API_MySIRH.DTOs
{
    public class CandidatDTO : DtoBase
    {
        [Required(ErrorMessage = "le nom est obligatoire")]
        public string? Nom { get; set; }
        [Required(ErrorMessage = "le prenom est obligatoire")]
        public string? Prenom { get; set; }
        [Required(ErrorMessage = "la date de naissance est obligatoire")]
        public DateTime? DateNaissance { get; set; }
        [Required(ErrorMessage = "la civilité est obligatoire")]
        [StringLength(1, ErrorMessage = "Civilité doit être soit 'H'~Homme soit 'F'~Femme.")]
        public string? Civilite { get; set; }
        [Required(ErrorMessage = "La émail est obligatoire")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "La émail est obligatoire")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string? Telephone { get; set; }
        public DateTime? DatePremiereExperience { get; set; }
        public DateTime? DateDeNaissance { get; set; }
        public decimal? SalaireActuel { get; set; }
        public decimal? PropositionSalariale { get; set; }
        public string? ResidenceActuelle { get; set; }
        public string? EmploiEncore { get; set; }
        public int PosteId { get; set; }
        public int PosteNiveauId { get; set; }
        public string? Commentaire { get; set; }

        public string? ImageUrl { get; set; }

        public string? CVUrl { get; set; }
    }
}
