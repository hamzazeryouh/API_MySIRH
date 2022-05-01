namespace API_MySIRH.Entities.Evaluation
{
    public class Evaluation:EntityBase
    {
        public Evaluation()
        {
            Commenters=new HashSet<Commenter>();
        }
       public string?  Evaluateur { get; set; }  
       public string? DateEntretien { get; set; }
       public Candidat? Candidat { get; set; }   
       public  ICollection<Commenter> Commenters { get; set; }
        public Template? Template { get; set; }
    }
}
