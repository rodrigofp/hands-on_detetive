using System.Threading.Tasks;
using Detetive_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Detetive_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmasController : ControllerBase
    {
        public IRepository _repo { get; }
        public ArmasController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try{
                var resultado = await _repo.GetAllArmas();

                return Ok(resultado);
            }
            catch(System.Exception ex){
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}.");
            }
        }
    }
}