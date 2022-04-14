namespace API_MySIRH.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; } = DateTime.Now;
    }
}
