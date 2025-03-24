using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuardianLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController(IEstadoService _estadoService) : ControllerBase
    {
        public IEstadoService EstadoService { get; } = _estadoService;

        [HttpGet("{paisId}")]
        public async Task<IActionResult> GetEstados(int paisId)
        {
            try
            {
                var estados = await EstadoService.GetEstadosBYPaisIdAsync(paisId);

                if (estados == null) return NoContent();

                return Ok(estados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("EstadoId/{estadoId}")]
        public async Task<IActionResult> GetEstadoById(int estadoId)
        {
            try
            {
                var estado = await EstadoService.GetEstadoByIdAsync(estadoId);

                if (estado == null) return NoContent();

                return Ok(estado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostEstado(EstadoDto estado)
        {
            try
            {
                var result = await EstadoService.AddEstadoAsync(estado);

                if (!result) return BadRequest("Erro ao tentar cadastrar estado!");

                return Ok("Estado cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutEstado(EstadoDto estadoModel)
        {
            try
            {
                var estado = await EstadoService.UpdateEstadoAsync(estadoModel);

                if (estado == null) return NotFound("Estado não encontrado");

                return Ok(estado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{estadoId}")]
        public async Task<IActionResult> DeleteEstado(int estadoId)
        {
            try
            {
                var result = await EstadoService.DeleteEstadoAsync(estadoId);

                if (result) return Ok("Estado deletado com sucesso.");

                return BadRequest("Erro ao tentar deletar o estado.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}