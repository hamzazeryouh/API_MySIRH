namespace API_MySIRH.Entities
{
    public  class Evaluation:EntityBase<int>
    {
        public Evaluation()
        {
            Commenters=new HashSet<Commenter>();
        }
       public string?  Evaluateur { get; set; }  
       public DateTime? DateEntretien { get; set; }
       public Candidat? Candidat { get; set; }   
       public  ICollection<Commenter> Commenters { get; set; }
        public Template? Template { get; set; }
    }
}
