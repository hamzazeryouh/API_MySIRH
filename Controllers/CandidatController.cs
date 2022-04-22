using API_MySIRH.Data;
using API_MySIRH.DTOs;
using API_MySIRH.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace API_MySIRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            catch(Exception ex)
            {
                throw ex;
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
        public async Task<IActionResult> ImportExcel()
        {
            var files = Request.Form.Files[0];
            if (!this.CheckIfExcelFile(files) || files.Length==null) return BadRequest();

            try
            {
                var file = await this._CandidatService.ImportExcel(files);
              return  Ok(file);
            }
            catch(Exception ex)
            {
             return   BadRequest(ex);
            }


        }

        private bool CheckIfExcelFile(IFormFile file)
        {
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            return (extension == ".xlsx" || extension == ".xls"); // Change the extension based on your need
        }

        [HttpPost("UploadImage/{id}"), DisableRequestSizeLimit]
        public async Task<IActionResult> Uploadimage(int id)
        {
            var file = Request.Form.Files[0];
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            if (extension == ".jpg"  || extension == ".JPEG"|| extension == ".png"|| extension==  ".jfif")
            {
                var candidat = await _CandidatService.Upload(file, id,false);
                return Ok(candidat);
            }
            return BadRequest();
           
        }

        [HttpPost("UploadCV/{id}"), DisableRequestSizeLimit]
        public async Task<IActionResult> Uploadcv(int id)
        {

            var file = Request.Form.Files[0];
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            if (extension == ".pdf")
            {
                var candidat = await _CandidatService.Upload(file, id,true);
                return Ok(candidat);
            }
            return BadRequest();

        }


        [HttpGet("GetFile/{uniquename}")]
        public async Task<IActionResult> GetCandidat(string uniquename)
        {
            return await _CandidatService.GetFile(uniquename);
        }





    }
}