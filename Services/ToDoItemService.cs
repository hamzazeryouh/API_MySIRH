using API_MySIRH.DTOs;
using API_MySIRH.Entities;
using API_MySIRH.Interfaces;
using AutoMapper;

namespace API_MySIRH.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemsRepository _toDoItemsRepository;
        private readonly IMapper _mapper;

        public ToDoItemService(IToDoItemsRepository toDoItemsRepository, IMapper mapper)
        {
            this._toDoItemsRepository = toDoItemsRepository;
            this._mapper = mapper;
        }
        public async Task<ToDoItemDTO> AddToDoItem(ToDoItemDTO toDoItem)
        {
            var returnedToDoItem = await _toDoItemsRepository.AddToDoItem(_mapper.Map<ToDoItem>(toDoItem));
            return _mapper.Map<ToDoItemDTO>(returnedToDoItem);
        }

        public async Task DeleteToDoItem(int id)
        {
            await _toDoItemsRepository.DeleteToDoItem(id);
        }

        public async Task<ToDoItemDTO> GetToDoItem(int id)
        {
            var result = await _toDoItemsRepository.GetToDoItem(id);
            return _mapper.Map<ToDoItemDTO>(result);
        }

        public async Task<IEnumerable<ToDoItemDTO>> GetToDoItems()
        {
            var result = await _toDoItemsRepository.GetToDoItems();
            return _mapper.Map<IEnumerable<ToDoItem>, IEnumerable<ToDoItemDTO>>(result);
        }

        public async Task UpdateToDoItem(int id, ToDoItemDTO toDoItemDTO)
        {
            var toDoItem = _mapper.Map<ToDoItem>(toDoItemDTO);
            await _toDoItemsRepository.UpdateToDoItem(id, toDoItem);
        }
    }
}
