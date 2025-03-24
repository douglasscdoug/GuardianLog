using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuardianLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloVeiculoController(IModeloVeiculoService _modeloVeiculoService) : ControllerBase
    {
        public IModeloVeiculoService ModeloVeiculoService { get; } = _modeloVeiculoService;

        [HttpGet("ModeloByMarca/{marcaId}")]
        public async Task<IActionResult> GetModelosByMarcaId(int marcaId)
        {
            try
            {
                var modelos = await ModeloVeiculoService.GetModelosVeiculoByMarcaIdAsync(marcaId);

                if (modelos == null) return NoContent();

                return Ok(modelos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("ModeloById/{modeloId}")]
        public async Task<IActionResult> GetModeloById(int modeloId)
        {
            try
            {
                var modelo = await ModeloVeiculoService.GetModeloVeiculoByIdAsync(modeloId);

                if (modelo == null) return NoContent();

                return Ok(modelo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostModelo(ModeloVeiculoDto model)
        {
            try
            {
                var result = await ModeloVeiculoService.AddModeloAsync(model);

                if(result) return Ok("Modelo cadastrado com sucesso");

                return BadRequest("Erro ao tentar cadastrar o modelo");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutModelo(ModeloVeiculoDto model)
        {
            try
            {
                var modelo = await ModeloVeiculoService.UpdateModeloAsync(model);

                if(modelo == null) return NotFound("Modelo não encontrado!");

                return Ok(modelo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{modeloId}")]
        public async Task<IActionResult> DeleteModelo(int modeloId)
        {
            try
            {
                var result = await ModeloVeiculoService.DeleteModeloAsync(modeloId);

                if(result) return Ok("Modelo deletado com sucesso.");

                return BadRequest("Erro ao tentar deletar modelo");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}