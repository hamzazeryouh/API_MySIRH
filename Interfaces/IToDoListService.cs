using API_MySIRH.DTOs;

namespace API_MySIRH.Interfaces
{
    public interface IToDoListService
    {
        Task<IEnumerable<ToDoListDTO>> GetToDoLists();
        Task<ToDoListDTO> GetToDoList(int id);
        Task UpdateToDoList(int id, ToDoListDTO toDoList);
        Task<ToDoListDTO> AddToDoList(ToDoListDTO toDoList);
        Task DeleteToDoList(int id);
    }
}
