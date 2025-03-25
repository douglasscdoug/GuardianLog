using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuardianLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoVeiculoController(ITipoVeiculoService _tipoVeiculoService) : ControllerBase
    {
        public ITipoVeiculoService TipoVeiculoService { get; } = _tipoVeiculoService;

        [HttpGet]
        public async Task<IActionResult> GetAllTiposVeiculo()
        {
            try
            {
                var tpsVeiculo = await TipoVeiculoService.GetAllTiposVeiculoAsync();

                if (tpsVeiculo == null) return NoContent();

                return Ok(tpsVeiculo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("TipoVeiculoById/{tpVeiculoId}")]
        public async Task<IActionResult> GetTipoVeiculoById(int tpVeiculoId)
        {
            try
            {
                var tpVeiculo = await TipoVeiculoService.GetTipoVeiculoByIdAsync(tpVeiculoId);

                if (tpVeiculo == null) return NoContent();

                return Ok(tpVeiculo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutTipoVeiculo(TipoVeiculoDto model)
        {
            try
            {
                var tpVeiculo = await TipoVeiculoService.SalvarTipoVeiculoAsync(model);

                if (tpVeiculo) return Ok("Tipo de veículo salvo com sucesso.");

                return BadRequest("Erro ao tentar salvar o tepo de veiculo.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}