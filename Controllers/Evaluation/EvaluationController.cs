using API_MySIRH.DTOs;
using API_MySIRH.Helpers;
using API_MySIRH.Services.EvaluationService;
using Microsoft.AspNetCore.Mvc;

namespace API_MySIRH.Controllers.Evaluation
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : BaseController
    {
        private readonly IEvaluationService _EvaluationService;

        public EvaluationController(IEvaluationService EvaluationService)
            => _EvaluationService = EvaluationService;



        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        
        public async Task<ActionResult<Result<EvaluationDTO>>> GetAllAsync([FromQuery] ListFilterOption filterOption)
           => Ok(await _EvaluationService.GetAllAsync(filterOption));


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<EvaluationDTO>>> Get(int id)
          => ActionResultFor(await _EvaluationService.GetByIdAsync(id));

        /// <summary>
        /// create a new user
        /// </summary>
        /// <param name="userModel">the user model</param>
        /// <returns>the newly created user</returns>
        [HttpPost("Create")]

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<EvaluationDTO>>> Create([FromBody] EvaluationDTO Model)
            => ActionResultFor(await _EvaluationService.CreateAsync(Model));

        /// <summary>
        /// delete the user with the given Id
        /// </summary>
        /// <param name="id">the id of the user to be deleted</param>
        /// <returns>an operation result</returns>
        [HttpPost("Delete/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(int id)
            => ActionResultFor(await _EvaluationService.DeleteAsync(id));



        [HttpPost("Update/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<EvaluationDTO>>> Update(int id, [FromBody] EvaluationDTO Model)
=> ActionResultFor(await _EvaluationService.UpdateAsync(id, Model));
    }
}
