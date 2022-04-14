using API_MySIRH.Data;
using API_MySIRH.DTOs;
using API_MySIRH.Entities;
using API_MySIRH.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_MySIRH.Repositories
{
    public class ToDoItemsRepository : IToDoItemsRepository
    {
        private readonly DataContext _context;

        public ToDoItemsRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task DeleteToDoItem(int id)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(id);
            if (toDoItem != null)
            {
                _context.ToDoItems.Remove(toDoItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ToDoItem> GetToDoItem(int id)
        {
            return await _context.ToDoItems.FindAsync(id);
        }

        public async Task<IEnumerable<ToDoItem>> GetToDoItems()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<ToDoItem> AddToDoItem(ToDoItem toDoItem)
        {
            _context.ToDoItems.Add(toDoItem);
            await _context.SaveChangesAsync();
            return toDoItem;
        }

        public async Task UpdateToDoItem(int id, ToDoItem toDoItem)
        {
            _context.Entry(toDoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public bool ToDoItemExists(int id)
        {
            return _context.ToDoItems.Any(e => e.Id == id);
        }
    }
}
