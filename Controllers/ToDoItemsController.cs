using Microsoft.AspNetCore.Mvc;
using API_MySIRH.Interfaces;
using API_MySIRH.DTOs;

namespace API_MySIRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IToDoItemService _toDoItemService;

        public string Message { get; set; } = String.Empty;

        public ToDoItemsController(ILogger<ToDoItemsController> logger, IToDoItemService toDoItemService)
        {
            _logger = logger;
            _toDoItemService = toDoItemService;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItemDTO>>> GetToDoItems()
        {
            Message = $"About page visited at {DateTime.UtcNow.ToLongTimeString()}";
            _logger.LogInformation(Message);

            var result = await _toDoItemService.GetToDoItems();
            return Ok(result);

            //return Ok(await _toDoItemsRepository.GetToDoItems());
        }

        // GET: api/ToDoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemDTO>> GetToDoItem(int id)
        {
            var toDoItem = await _toDoItemService.GetToDoItem(id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return toDoItem;

        }

        // PUT: api/ToDoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDoItem(int id, ToDoItemDTO toDoItem)
        {
            if (id != toDoItem.Id)
            {
                return BadRequest();
            }

            try
            {
                await _toDoItemService.UpdateToDoItem(id, toDoItem);
            }
            catch 
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/ToDoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDoItemDTO>> AddToDoItem(ToDoItemDTO toDoItem)
        {
            var returnedItem = await _toDoItemService.AddToDoItem(toDoItem);
            return CreatedAtAction("GetToDoItem", new { id = returnedItem.Id }, returnedItem);
        }

        // DELETE: api/ToDoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(int id)
        {
            var toDoItem = await _toDoItemService.GetToDoItem(id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            await _toDoItemService.DeleteToDoItem(id);

            return NoContent();
        }

    }
}
