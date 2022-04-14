using Microsoft.AspNetCore.Mvc;
using API_MySIRH.Interfaces;
using API_MySIRH.DTOs;

namespace API_MySIRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemosController : ControllerBase
    {
        private readonly ILogger<MemosController> _logger;
        private readonly IMemoService _memoService;

        public MemosController(ILogger<MemosController> logger, IMemoService memoService)
        {
            this._logger = logger;
            this._memoService = memoService;
        }

        // GET: api/Memos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemoDTO>>> GetMemos()
        {
            var result = await _memoService.GetMemos();
            return Ok(result);
        }

        // GET: api/Memos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemoDTO>> GetMemo(int id)
        {
            var memo = await _memoService.GetMemo(id);

            if (memo == null)
            {
                return NotFound();
            }

            return memo;
        }

        // PUT: api/Memos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemo(int id, MemoDTO memo)
        {
            if (id != memo.Id)
            {
                return BadRequest();
            }

            try
            {
                await _memoService.UpdateMemo(id, memo);
            }
            catch
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Memos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MemoDTO>> PostMemo(MemoDTO memo)
        {
            var returnedMemo = await _memoService.AddMemo(memo);
            return CreatedAtAction("GetMemo", new { id = returnedMemo.Id }, returnedMemo);
        }

        // DELETE: api/Memos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMemo(int id)
        {
            var memoToDelete = await _memoService.GetMemo(id);
            if (memoToDelete == null)
            {
                return NotFound();
            }

            await _memoService.DeleteMemo(id);

            return NoContent();
        }
    }
}
