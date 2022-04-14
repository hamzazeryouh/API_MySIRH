namespace API_MySIRH.Entities
{
    public class ToDoItem : EntityBase
    {
        public int Ordre { get; set; } 
        public string Titre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Boolean Statut { get; set; }
        public int ToDoListId { get; set; }
        public ToDoList? ToDoList { get; set; }
    }
}
