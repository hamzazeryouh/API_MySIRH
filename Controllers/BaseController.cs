using API_MySIRH.Enums;
using API_MySIRH.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API_MySIRH.Controllers
{
  
        [ApiController]
        public class BaseController : ControllerBase
        {
            /// <summary>
            /// create an instant of <see cref="BaseController"/>
            /// </summary>
            public BaseController()
            { }

            /// <summary>
            /// this method is used to return the proper action result type
            /// </summary>
            /// <typeparam name="TResult">the type of the Result being processed</typeparam>
            /// <param name="taskResult">the result to process</param>
            /// <returns>the proper Action Result base on the passed in Result</returns>
            public async Task<ActionResult<TResult>> ActionResultForAsync<TResult>(Task<TResult> taskResult)
                where TResult : Result => ActionResultFor(await taskResult);

            /// <summary>
            /// this method is used to return the proper action result type
            /// </summary>
            /// <typeparam name="TResult">the type of the Result being processed</typeparam>
            /// <param name="result">the result to process</param>
            /// <returns>the proper Action Result base on the passed in Result</returns>
            public ActionResult<TResult> ActionResultFor<TResult>(TResult result)
                where TResult : Result
            {
                // the operation has failed
                if (result.Status == ResultStatus.Failed)
                {
                    // something went wrong (exception)
                    if (result.HasError)
                        return StatusCode(500, result);

                    // result not found
                    if (!result.HasValue || result.MessageCode == MsgCode.OperationFailedNotFound.ToString())
                        return NotFound(result);

                    // user is not authorized
                    if (result.MessageCode.Equals(MsgCode.Unauthorized.ToString()))
                        return StatusCode(StatusCodes.Status403Forbidden, result);

                    //if nothing bad request
                    return BadRequest(result);
                }

                // all set, return the operation result
                return Ok(result);
            }

        }
    }

