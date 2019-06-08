using Microsoft.AspNetCore.Mvc;

namespace Detetive_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocaisController : ControllerBase
    {
        public LocaisController(){
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}