using API_MySIRH.Data;
using API_MySIRH.DTOs;
using API_MySIRH.DTOs.MDM;
using API_MySIRH.Interfaces;
using API_MySIRH.Interfaces.InterfaceServices.MDM;
using Microsoft.AspNetCore.Mvc;


namespace API_MySIRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize()]
    public class PosteNiveauController : ControllerBase
    {
        private readonly IPosteNiveauService _PosteNiveauService;

        public PosteNiveauController(IPosteNiveauService PosteNiveauervice)
        {
            this._PosteNiveauService = PosteNiveauervice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosteNiveauDTO>>> GetPosteNiveau()
        {
            var result = await this._PosteNiveauService.GetPosteNiveaus();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PosteNiveauDTO>> GetPosteNiveau(int id)
        {
            return Ok(await this._PosteNiveauService.GetPosteNiveau(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddPosteNiveau(PosteNiveauDTO PosteNiveauDTO)
        {
            var PosteNiveauToCreate = await this._PosteNiveauService.AddPosteNiveau(PosteNiveauDTO);
            return CreatedAtAction(nameof(GetPosteNiveau), new { id = PosteNiveauToCreate.Id }, PosteNiveauToCreate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PosteNiveauDTO>> UpdatePosteNiveau(int id, PosteNiveauDTO PosteNiveauDTO)
        {
            if (id != PosteNiveauDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await this._PosteNiveauService.UpdatePosteNiveau(id, PosteNiveauDTO);
            }
            catch
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosteNiveau(int id)
        {
            var PosteNiveau = await this._PosteNiveauService.GetPosteNiveau(id);
            if (PosteNiveau is null)
                return NotFound();
            await this._PosteNiveauService.DeletePosteNiveau(id);
            return NoContent();
        }
    }
}