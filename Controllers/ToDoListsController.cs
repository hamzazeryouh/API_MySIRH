using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using API_MySIRH.Entities;
using API_MySIRH.Interfaces;
using API_MySIRH.DTOs;

namespace API_MySIRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly IToDoListService _toDoListService;

        public ToDoListsController(IToDoListService toDoListService)
        {
            this._toDoListService = toDoListService;
        }

        // GET: api/ToDoLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoListDTO>>> GetToDoLists()
        {
            var result = await _toDoListService.GetToDoLists();
            return Ok(result);
        }

        // GET: api/ToDoLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoListDTO>> GetToDoList(int id)
        {
            var toDoList = await _toDoListService.GetToDoList(id);

            if (toDoList == null)
            {
                return NotFound();
            }

            return toDoList;
        }

        // PUT: api/ToDoLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDoList(int id, ToDoListDTO toDoListDTO)
        {
            if (id != toDoListDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                await _toDoListService.UpdateToDoList(id, toDoListDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            
            return NoContent();
        }

        // POST: api/ToDoLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDoList>> PostToDoList(ToDoListDTO toDoListDTO)
        {
            var toDoList = await _toDoListService.AddToDoList(toDoListDTO);
            return CreatedAtAction("GetToDoList", new { id = toDoList.Id }, toDoList);
        }

        // DELETE: api/ToDoLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoList(int id)
        {
            await _toDoListService.DeleteToDoList(id);            
            return NoContent();
        }
    }
}
