using Microsoft.AspNetCore.Mvc;

namespace Detetive_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuspeitosController : ControllerBase
    {
        public SuspeitosController(){

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}