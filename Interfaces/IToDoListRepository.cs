using API_MySIRH.DTOs;
using API_MySIRH.Entities;

namespace API_MySIRH.Interfaces
{
    public interface IToDoListRepository
    {
        Task<IEnumerable<ToDoList>> GetToDoLists();
        Task<ToDoList> GetToDoList(int id);
        Task UpdateToDoList(int id, ToDoList toDoList);
        Task<ToDoList> AddToDoList(ToDoList toDoList);
        Task DeleteToDoList(int id);
        bool ToDoListExists(int id);
    }
}
