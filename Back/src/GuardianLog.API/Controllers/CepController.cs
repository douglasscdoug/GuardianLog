using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuardianLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController(ICepService _cepService) : ControllerBase
    {
        public ICepService CepService { get; } = _cepService;

        [HttpGet("{numeroCep}")]
        public async Task<IActionResult> GetCep(string numeroCep)
        {
            try
            {
                var cep = await CepService.GetCepAsync(numeroCep);

                if(cep == null) return NoContent();

                return Ok(cep);
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCep(CEPRequestDto model)
        {
            try
            {
                var result = await CepService.AddCepAsync(model);

                if(result) return Ok("CEP cadastrado com sucesso!");

                return BadRequest("Erro ao tentar cadastrar CEP!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
