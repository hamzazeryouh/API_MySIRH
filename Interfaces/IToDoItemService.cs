using API_MySIRH.DTOs;

namespace API_MySIRH.Interfaces
{
    public interface IToDoItemService
    {
        Task<IEnumerable<ToDoItemDTO>> GetToDoItems();
        Task<ToDoItemDTO> GetToDoItem(int id);
        Task UpdateToDoItem(int id, ToDoItemDTO toDoItem);
        Task<ToDoItemDTO> AddToDoItem(ToDoItemDTO toDoItem);
        Task DeleteToDoItem(int id);
    }
}
