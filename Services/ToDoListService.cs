using API_MySIRH.DTOs;
using API_MySIRH.Entities;
using API_MySIRH.Interfaces;
using AutoMapper;

namespace API_MySIRH.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IToDoListRepository _toDoListRepository;
        private readonly IMapper _mapper;

        public ToDoListService(IToDoListRepository toDoListRepository, IMapper mapper)
        {
            this._toDoListRepository = toDoListRepository;
            this._mapper = mapper;
        }
        public async Task<ToDoListDTO> AddToDoList(ToDoListDTO toDoList)
        {
            var returnedToDoList = await _toDoListRepository.AddToDoList(_mapper.Map<ToDoList>(toDoList));
            return _mapper.Map<ToDoListDTO>(returnedToDoList);
           
        }

        public async Task DeleteToDoList(int id)
        {
            await _toDoListRepository.DeleteToDoList(id);
        }

        public async Task<ToDoListDTO> GetToDoList(int id)
        {
            var result = await _toDoListRepository.GetToDoList(id);
            return _mapper.Map<ToDoListDTO>(result);
        }

        public async Task<IEnumerable<ToDoListDTO>> GetToDoLists()
        {
            var result = await _toDoListRepository.GetToDoLists();
            return _mapper.Map<IEnumerable<ToDoList>, IEnumerable<ToDoListDTO>>(result);
        }

        public async Task UpdateToDoList(int id, ToDoListDTO toDoListDTO)
        {
            var toDoList = _mapper.Map<ToDoList>(toDoListDTO);
            await _toDoListRepository.UpdateToDoList(id, toDoList);
        }
    }
}
