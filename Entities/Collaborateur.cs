namespace API_MySIRH.Entities
{
    public class Collaborateur : EntityBase
    {
        public string Nom { get; set; } = String.Empty;
        public string Prenom { get; set; } = String.Empty;
        public DateTime DateNaissance { get; set; }
        public string Matricule { get; set; } = String.Empty;
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
