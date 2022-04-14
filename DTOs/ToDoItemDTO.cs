namespace API_MySIRH.DTOs
{
    public class ToDoItemDTO
    {
        public int Id { get; set; }
        public int Ordre { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set;}
        public Boolean Statut { get; set; }
        public int ToDoListId { get; set; }
        public ToDoListDTO? ToDoList { get; set; }
        //TO DO : To remove
        public int MyProperty { get; set; }
    }
}
