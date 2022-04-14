namespace API_MySIRH.Entities
{
    public class ToDoList : EntityBase
    {
        public int Ordre { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<ToDoItem> ToDoItemList { get; set; } = null!;

    }
}
