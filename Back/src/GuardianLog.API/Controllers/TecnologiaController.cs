using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuardianLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnologiaController(ITecnologiaService _tecnologiaService) : ControllerBase
    {
        public ITecnologiaService TecnologiaService { get; } = _tecnologiaService;

        [HttpGet]
        public async Task<IActionResult> GetAllTecnologias()
        {
            try
            {
                var tecnologias = await TecnologiaService.GetAllTecnologiasAsync();

                if (tecnologias == null) return NoContent();

                return Ok(tecnologias);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("TecnologiaById/{tecnologiaId}")]
        public async Task<IActionResult> GetTecnologiaById(int tecnologiaId)
        {
            try
            {
                var tecnologia = await TecnologiaService.GetTecnologiaByIdAsync(tecnologiaId);

                if (tecnologia == null) return NoContent();

                return Ok(tecnologia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostTecnologia(TecnologiaRastreamentoDto model)
        {
            try
            {
                var result = await TecnologiaService.AddTecnologiaAsync(model);

                if (result) return Ok("Tecnologia cadastrada com sucesso!");

                return BadRequest("Erro ao tentar salvar a tecnologia.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutTecnologia(TecnologiaRastreamentoDto model)
        {
            try
            {
                var tecnologia = await TecnologiaService.UpdateTecnologiaAsync(model);

                if(tecnologia == null) return NotFound("Tecnologia não encontrada");

                return Ok(tecnologia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}