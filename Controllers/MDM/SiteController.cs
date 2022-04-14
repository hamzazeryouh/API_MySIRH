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
    public class SiteController : ControllerBase
    {
        private readonly ISiteService _SiteService;

        public SiteController(ISiteService Siteervice)
        {
            this._SiteService = Siteervice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SiteDTO>>> GetSite()
        {
            var result = await this._SiteService.GetSites();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SiteDTO>> GetSite(int id)
        {
            return Ok(await this._SiteService.GetSite(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddSite(SiteDTO SiteDTO)
        {
            var SiteToCreate = await this._SiteService.AddSite(SiteDTO);
            return CreatedAtAction(nameof(GetSite), new { id = SiteToCreate.Id }, SiteToCreate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SiteDTO>> UpdateSite(int id, SiteDTO SiteDTO)
        {
            if (id != SiteDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await this._SiteService.UpdateSite(id, SiteDTO);
            }
            catch
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSite(int id)
        {
            var Site = await this._SiteService.GetSite(id);
            if (Site is null)
                return NotFound();
            await this._SiteService.DeleteSite(id);
            return NoContent();
        }
    }
}