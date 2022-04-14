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
    public class SkillCenterController : ControllerBase
    {
        private readonly ISkillCenterService _SkillCenterService;

        public SkillCenterController(ISkillCenterService SkillCenterervice)
        {
            this._SkillCenterService = SkillCenterervice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillCenterDTO>>> GetSkillCenter()
        {
            var result = await this._SkillCenterService.GetSkillCenters();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SkillCenterDTO>> GetSkillCenter(int id)
        {
            return Ok(await this._SkillCenterService.GetSkillCenter(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddSkillCenter(SkillCenterDTO SkillCenterDTO)
        {
            var SkillCenterToCreate = await this._SkillCenterService.AddSkillCenter(SkillCenterDTO);
            return CreatedAtAction(nameof(GetSkillCenter), new { id = SkillCenterToCreate.Id }, SkillCenterToCreate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SkillCenterDTO>> UpdateSkillCenter(int id, SkillCenterDTO SkillCenterDTO)
        {
            if (id != SkillCenterDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await this._SkillCenterService.UpdateSkillCenter(id, SkillCenterDTO);
            }
            catch
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkillCenter(int id)
        {
            var SkillCenter = await this._SkillCenterService.GetSkillCenter(id);
            if (SkillCenter is null)
                return NotFound();
            await this._SkillCenterService.DeleteSkillCenter(id);
            return NoContent();
        }
    }
}