namespace API_MySIRH.DTOs
{
    public class ToDoListDTO
    {
        public int Id { get; set; }
        public int Ordre { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public ICollection<ToDoItemDTO>? ToDoItemList { get; set; }
    }
}
