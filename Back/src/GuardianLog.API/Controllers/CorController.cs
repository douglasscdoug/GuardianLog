using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuardianLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorController(ICorService _corService) : ControllerBase
    {
        public ICorService CorService { get; } = _corService;

        [HttpGet]
        public async Task<IActionResult> GetAllCores()
        {
            try
            {
                var cores = await CorService.GetAllCoresAsync();

                if (cores == null) return NoContent();

                return Ok(cores);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("nomeCor/{nomeCor}")]
        public async Task<IActionResult> GetCoresByNome(string nomeCor)
        {
            try
            {
                var cores = await CorService.GetCoresByNomeAsync(nomeCor);

                if (cores == null) return NoContent();

                return Ok(cores);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCor(CorDto cor)
        {
            try
            {
                var result = await CorService.AddCorAsync(cor);

                if (result) return Ok("Cor cadastrada com sucesso!");

                return BadRequest("Erro ao tentar cadastrar cor!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutCor(CorDto corModel)
        {
            try
            {
                var cor = await CorService.UpdateCorAsync(corModel);

                if (cor == null) return NotFound("Cor não encontrada!");

                return Ok(cor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{corId}")]
        public async Task<IActionResult> DeleteCor(int corId)
        {
            try
            {
                var result = await CorService.DeleteCorAsync(corId);

                if(result) return Ok($"Cor id {corId} deletada com sucesso");

                return BadRequest("Erro ao tentar deletar cor!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
