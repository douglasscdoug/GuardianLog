using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuardianLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaVeiculoController(IMarcaVeiculoService _marcaVeiculoService) : ControllerBase
    {
        public IMarcaVeiculoService MarcaVeiculoService { get; } = _marcaVeiculoService;

        [HttpGet]
        public async Task<IActionResult> GetAllMarcas()
        {
            try
            {
                var marcas = await MarcaVeiculoService.GetAllMarcasVeiculosAsync();

                if(marcas == null) return NoContent();

                return Ok(marcas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("MarcaNome/{marcaNome}")]
        public async Task<IActionResult> GetMarcasByNome(string marcaNome)
        {
            try
            {
                var marcas = await MarcaVeiculoService.GetMarcasVeiculosByNomeAsync(marcaNome);

                if(marcas == null) return NoContent();

                return Ok(marcas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("MarcaId/{marcaId}")]
        public async Task<IActionResult> GetMarcaById(int marcaId)
        {
            try
            {
                var marca = await MarcaVeiculoService.GetMarcaVeiculoByIdAsync(marcaId);

                if(marca == null) return NoContent();

                return Ok(marca);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostMarca(MarcaVeiculoDto marcaModel)
        {
            try
            {
                var result = await MarcaVeiculoService.AddMarcaVeiculoAsync(marcaModel);

                if (!result) return BadRequest("Erro ao tentar cadastrar marca!");

                return Ok("Marca cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutMarca(MarcaVeiculoDto marcaModel)
        {
            try
            {
                var marca = await MarcaVeiculoService.UpdateMarcaVeiculoAsync(marcaModel);

                if(marca == null) return NotFound("Marca não encontrada");

                return Ok(marca);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{marcaId}")]
        public async Task<IActionResult> DeleteMarca(int marcaId)
        {
            try
            {
                var result = await MarcaVeiculoService.DeleteMarcaVeiculoAsync(marcaId);

                if (result) return Ok("Marca deletada com sucesso.");

                return BadRequest("Erro ao tentar deletar o estado.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
