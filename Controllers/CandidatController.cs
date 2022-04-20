using API_MySIRH.Data;
using API_MySIRH.DTOs;
using API_MySIRH.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

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



        [HttpGet("ExportExcel")]
        public async Task<FileStreamResult> ExportExcel()
        {
            var file = await this._CandidatService.ExportExcel();
           return file;
        }

        [HttpPost("ImportExcel")]
        public async Task<IActionResult> ImportExcel(IFormFile Excel)
        {
            try
            {
                var file = await this._CandidatService.ImportExcel(Excel);
              return  Ok(file);
            }
            catch(Exception ex)
            {
             return   BadRequest(ex);
            }


        }

        [HttpPost("Upload"), DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


    }
}