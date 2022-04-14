using API_MySIRH.Data;
using API_MySIRH.DTOs;
using API_MySIRH.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API_MySIRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize()]
    public class CollaborateursController : ControllerBase
    {
        private readonly ICollaborateurService _collaborateurService;

        public CollaborateursController(ICollaborateurService collaborateurService)
        {
            this._collaborateurService = collaborateurService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollaborateurDTO>>> GetCollaborateurs()
        {
            var result = await this._collaborateurService.GetCollaborateurs();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CollaborateurDTO>> GetCollaborateur(int id)
        {
            return Ok(await this._collaborateurService.GetCollaborateur(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddCollaborateur(CollaborateurDTO collaborateurDTO)
        {
            var collaborateurToCreate = await this._collaborateurService.AddCollaborateur(collaborateurDTO);
            return CreatedAtAction(nameof(GetCollaborateurs), new { id = collaborateurToCreate.Id }, collaborateurToCreate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CollaborateurDTO>> UpdateCollaborateur(int id, CollaborateurDTO collaborateurDTO)
        {
            if (id != collaborateurDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await this._collaborateurService.UpdateCollaborateur(id, collaborateurDTO);
            }
            catch
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollaborateur(int id)
        {
            var collaborateur = await this._collaborateurService.GetCollaborateur(id);
            if (collaborateur is null)
                return NotFound();
            await this._collaborateurService.DeleteCollaborateur(id);
            return NoContent();
        }
    }
}