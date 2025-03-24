using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuardianLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCarretaController(ITipoCarretaService _tipoCarretaService) : ControllerBase
    {
        public ITipoCarretaService TipoCarretaService { get; } = _tipoCarretaService;

        [HttpGet]
        public async Task<IActionResult> GetTiposCarreta()
        {
            try
            {
                var tpsCarreta = await TipoCarretaService.GetAllTiposCarretaAsync();

                if(tpsCarreta == null) return NoContent();

                return Ok(tpsCarreta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("TipoCarretaById/{tpCarretaId}")]
        public async Task<IActionResult> GetTipoCarretaById(int tpCarretaId)
        {
            try
            {
                var tpCarreta = await TipoCarretaService.GetTipoCarretaByIdAsync(tpCarretaId);

                if(tpCarreta == null) return NoContent();

                return Ok(tpCarreta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> SalvarTipoCarreta(TipoCarretaDto model)
        {
            try
            {
                var tpCarreta = await TipoCarretaService.SalvarTipoCarretaAsync(model);

                if(tpCarreta) return Ok("Tipo Carreta Salvo com sucesso!");

                return BadRequest("Erro ao tentar salvar Tipo Carreta");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
