using API_MySIRH.Data;
using API_MySIRH.DTOs;
using API_MySIRH.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API_MySIRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize()]
    public class CandidatController : ControllerBase
    {
        private readonly ICandidatService _CandidatService;

        public CandidatController(ICandidatService Candidatervice)
        {
            this._CandidatService = Candidatervice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidatDTO>>> GetCandidat()
        {
            var result = await this._CandidatService.GetCandidats();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CandidatDTO>> GetCandidat(int id)
        {
            return Ok(await this._CandidatService.GetCandidat(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddCandidat(CandidatDTO CandidatDTO)
        {
            var CandidatToCreate = await this._CandidatService.AddCandidat(CandidatDTO);
            return CreatedAtAction(nameof(GetCandidat), new { id = CandidatToCreate.Id }, CandidatToCreate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CandidatDTO>> UpdateCandidat(int id, CandidatDTO CandidatDTO)
        {
            if (id != CandidatDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await this._CandidatService.UpdateCandidat(id, CandidatDTO);
            }
            catch
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidat(int id)
        {
            var Candidat = await this._CandidatService.GetCandidat(id);
            if (Candidat is null)
                return NotFound();
            await this._CandidatService.DeleteCandidat(id);
            return NoContent();
        }
    }
}