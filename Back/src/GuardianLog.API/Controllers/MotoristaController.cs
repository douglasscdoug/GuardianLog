using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuardianLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoristaController(IMotoristaService _motoristaService) : ControllerBase
    {
        public IMotoristaService MotoristaService { get; } = _motoristaService;

        [HttpGet]
        public async Task<IActionResult> GetAllMotoristas()
        {
            try
            {
                var motoristas = await MotoristaService.GetAllMotoristasAsync();

                if(motoristas == null) return NoContent();

                return Ok(motoristas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("NomeMotorista/{nomeMotorista}")]
        public async Task<IActionResult> GetMotoristasByNome(string nomeMotorista)
        {
            try
            {
                var motoristas = await MotoristaService.GetMotoristasByNomeAsync(nomeMotorista);

                if(motoristas == null) return NoContent();

                return Ok(motoristas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("MotoristaId/{motoristaId}")]
        public async Task<IActionResult> GetMotoristaById(int motoristaId)
        {
            try
            {
                var motorista = await MotoristaService.GetMotoristaByIdAsync(motoristaId);

                if(motorista == null) return NoContent();

                return Ok(motorista);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostMotorista(MotoristaRequestDto model)
        {
            try
            {
                var motorista = await MotoristaService.AddMotoristaAsync(model);

                if(motorista == null) return NoContent();

                return Ok(motorista);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutMotorista(MotoristaRequestDto model)
        {
            try
            {
                var motorista = await MotoristaService.UpdateMotoristaAsync(model);

                if(motorista == null) return NotFound("Motorista não encontrado!");

                return Ok(motorista);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{motoristaId}")]
        public async Task<IActionResult> DeleteMotorista(int motoristaId)
        {
            try
            {
                var result = await MotoristaService.DeletemotoristaAsync(motoristaId);

                if(result) return Ok(new {message = "Deletado"});

                return BadRequest("Erro ao tentar deletar motorista!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message} - Inner: {ex.InnerException?.Message}");
            }
        }
    }
}
