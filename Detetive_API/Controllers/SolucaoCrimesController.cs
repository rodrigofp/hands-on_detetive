using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Detetive_API.Data;
using Detetive_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Detetive_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolucaoCrimesController : ControllerBase
    {
        public IRepository _repo { get; }
        public SolucaoCrimesController(IRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult> CompareWithTheory(SolucaoCrime model)
        {
            var solucao = await _repo.GetSolucaoCrime(model.Id);


            if(solucao.ArmaId == model.ArmaId &&
            solucao.LocalId == model.LocalId &&
            solucao.SuspeitoId == model.SuspeitoId){
                
                return Ok("0");
            }
            else{
                List<int> resultado = new List<int>();
                
                if(solucao.SuspeitoId != model.SuspeitoId){
                    resultado.Add(1);
                }

                if(solucao.LocalId == model.LocalId){
                    resultado.Add(2);
                }

                if(solucao.ArmaId == model.ArmaId){
                    resultado.Add(3);
                }
                
                var index = new Random().Next(resultado.Count);

                return Ok(resultado[index]);
            }
        }

        [HttpPost]
        public async Task<int> Post(SolucaoCrime model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return model.Id;
                }

                return -1;
            }
            catch (System.Exception)
            {
                return -1;
            }
        }

        [HttpDelete("{SolucaoCrimeId}")]
        public async Task<IActionResult> Delete(int SolucaoCrimeId)
        {
            try
            {
                var solucao = await _repo.GetSolucaoCrime(SolucaoCrimeId);

                _repo.Delete(solucao);
                
                return Ok();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}.");
            }
        }
    }
}