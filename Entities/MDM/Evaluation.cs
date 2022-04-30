namespace API_MySIRH.Entities.MDM
{
    public class Evaluation
    {
     public ICollection<EvaluationList> evaluationLists { get; set; }   
    }


    public class EvaluationList
    {
        public string? Title { get; set; }
        public List<Field>? Field { get; set; }

    }

    public class Field
    {
        public string? Dispayname { get; set; }
        public string? Value { get; set; }
        public string? Commenter { get; set; }
        public bool Requerd { get; set; }=false;
        public string Type { get; set; } = "text";
        public SubField? SubField { get; set; }
    }

    public class SubField
    {
        public string? Title { get; set; }
        public List<Field>? Field { get; set; }
    }

    
}
