using Microsoft.AspNetCore.Mvc;

namespace Detetive_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmasController : ControllerBase
    {
        public ArmasController(){
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}