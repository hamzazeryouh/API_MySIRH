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
    public class TypeContratController : ControllerBase
    {
        private readonly ITypeContratService _TypeContratService;

        public TypeContratController(ITypeContratService TypeContratervice)
        {
            this._TypeContratService = TypeContratervice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeContratDTO>>> GetTypeContrat()
        {
            var result = await this._TypeContratService.GetTypeContrats();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TypeContratDTO>> GetTypeContrat(int id)
        {
            return Ok(await this._TypeContratService.GetTypeContrat(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddTypeContrat(TypeContratDTO TypeContratDTO)
        {
            var TypeContratToCreate = await this._TypeContratService.AddTypeContrat(TypeContratDTO);
            return CreatedAtAction(nameof(GetTypeContrat), new { id = TypeContratToCreate.Id }, TypeContratToCreate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TypeContratDTO>> UpdateTypeContrat(int id, TypeContratDTO TypeContratDTO)
        {
            if (id != TypeContratDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await this._TypeContratService.UpdateTypeContrat(id, TypeContratDTO);
            }
            catch
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeContrat(int id)
        {
            var TypeContrat = await this._TypeContratService.GetTypeContrat(id);
            if (TypeContrat is null)
                return NotFound();
            await this._TypeContratService.DeleteTypeContrat(id);
            return NoContent();
        }
    }
}