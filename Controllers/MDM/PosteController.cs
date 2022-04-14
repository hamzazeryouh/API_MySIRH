using API_MySIRH.Data;
using API_MySIRH.DTOs;
using API_MySIRH.DTOs.MDM;
using API_MySIRH.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API_MySIRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize()]
    public class PosteController : ControllerBase
    {
        private readonly IPosteService _PosteService;

        public PosteController(IPosteService Posteervice)
        {
            this._PosteService = Posteervice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosteDTO>>> GetPoste()
        {
            var result = await this._PosteService.GetPostes();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PosteDTO>> GetPoste(int id)
        {
            return Ok(await this._PosteService.GetPoste(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddPoste(PosteDTO PosteDTO)
        {
            var PosteToCreate = await this._PosteService.AddPoste(PosteDTO);
            return CreatedAtAction(nameof(GetPoste), new { id = PosteToCreate.Id }, PosteToCreate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PosteDTO>> UpdatePoste(int id, PosteDTO PosteDTO)
        {
            if (id != PosteDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await this._PosteService.UpdatePoste(id, PosteDTO);
            }
            catch
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoste(int id)
        {
            var Poste = await this._PosteService.GetPoste(id);
            if (Poste is null)
                return NotFound();
            await this._PosteService.DeletePoste(id);
            return NoContent();
        }
    }
}