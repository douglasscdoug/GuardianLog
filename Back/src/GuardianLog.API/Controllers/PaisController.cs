using GuardianLog.Application;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuardianLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController(IPaisService _paisService) : ControllerBase
    {
        public IPaisService PaisService { get; } = _paisService;

        [HttpGet]
        public async Task<IActionResult> GetPaises()
        {
            try
            {
                var paises = await PaisService.GetAllPaisesAsync();

                if (paises == null) return NoContent();

                return Ok(paises);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostPaises(PaisDto paisModel)
        {
            try
            {
                var result = await PaisService.AddPaisAsync(paisModel);

                if (result) return Ok("Pais salvo com sucesso!");

                return BadRequest("Erro ao tentar salvar pais!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}