using API_MySIRH.Entities;

namespace API_MySIRH.Interfaces
{
    public interface IToDoItemsRepository
    {
        Task<IEnumerable<ToDoItem>> GetToDoItems();
        Task<ToDoItem> GetToDoItem(int id);
        Task UpdateToDoItem(int id, ToDoItem toDoItem);
        Task<ToDoItem> AddToDoItem(ToDoItem toDoItem);
        Task DeleteToDoItem(int id);
        bool ToDoItemExists(int id);
    }
}
