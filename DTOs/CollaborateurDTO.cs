using System.ComponentModel.DataAnnotations;

namespace API_MySIRH.DTOs
{
    public class CollaborateurDTO : DtoBase
    {
        [Required(ErrorMessage = "le nom est obligatoire")]
        public string Nom { get; set; } = String.Empty;

        [Required(ErrorMessage = "le prénom est obligatoire")]
        public string Prenom { get; set; } = String.Empty;

        [Required(ErrorMessage = "la date de naissance est obligatoire")]
        public DateTime DateNaissance { get; set; }

        [Required(ErrorMessage = "la matricule est obligatoire")]
        [StringLength(8, ErrorMessage = "La matricule se constitue de 5 charactéres minimum jusqu'à 10 charactéres maximum.", MinimumLength = 5)]
        public string Matricule { get; set; } = String.Empty;

        [Required(ErrorMessage = "la civilité est obligatoire")]
        [StringLength(1, ErrorMessage = "Civilité doit être soit 'H'~Homme soit 'F'~Femme.")]
        public string Civilite { get; set; } = String.Empty;

        /**
        / TODO : Foreign key & navigabilité
        *----------------------------------------------------
        *    public Post Poste { get; set; } 
        *    public SkillCenter SkillCenter { get; set; } 
        *    public Site Site { get; set; } 
        *    public Niveau Niveau { get; set; } 
        *    public TypeContrat TypeContrat { get; set; } 
        */

        public string ModeRecrutement { get; set; } = String.Empty;
        public DateTime? DatePremiereExperience { get; set; }

        public DateTime? DateEntreeSqli { get; set; }

        public DateTime? DateSortieSqli { get; set; }
        public DateTime? DateDebutStage { get; set; }

        public string Diplomes { get; set; } = String.Empty;
    }
}
