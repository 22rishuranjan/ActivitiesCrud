


using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CrudApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {


        protected ActionResult HandleResult<T>(ApiResponse<T> result)
        {
            if (result.Data == null) return NotFound();
            if (result.Success)
                return Ok(result);
         
            return BadRequest(result.Message);
        }

        
    }
}