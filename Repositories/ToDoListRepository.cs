using API_MySIRH.Data;
using API_MySIRH.Entities;
using API_MySIRH.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_MySIRH.Repositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly DataContext _context;
        public ToDoListRepository(DataContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<ToDoList>> GetToDoLists()
        {
            var result = await _context.ToDoLists
                 .Include(p => p.ToDoItemList)
                 .ToListAsync();
            return result;
        }
        public async Task<ToDoList> GetToDoList(int id)
        {
            return await _context.ToDoLists.FindAsync(id);
        }
        public async Task UpdateToDoList(int id, ToDoList toDoList)
        {
            _context.Entry(toDoList).State = EntityState.Modified;

            foreach (var item in toDoList.ToDoItemList)
            {
                if (item.Id != 0)
                {
                    _context.Entry(item).State = EntityState.Modified;
                }
                else
                {
                    _context.Entry(item).State = EntityState.Added;
                }
            }

            await _context.SaveChangesAsync();

        }
        public async Task<ToDoList> AddToDoList(ToDoList toDoList)
        {
            _context.ToDoLists.Add(toDoList);
            await _context.SaveChangesAsync();
            return toDoList;
        }
        public async Task DeleteToDoList(int id)
        {
            var toDoList = await _context.ToDoLists.FindAsync(id);
            if (toDoList != null)
            {
                _context.ToDoLists.Remove(toDoList);
                await _context.SaveChangesAsync();
            }
        }
        public bool ToDoListExists(int id)
        {
            return _context.ToDoLists.Any(e => e.Id == id);
        }
    }
}
