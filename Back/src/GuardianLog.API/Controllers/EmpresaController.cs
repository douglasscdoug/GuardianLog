using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuardianLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController(IEmpresaService _empresaService) : ControllerBase
    {
        public IEmpresaService EmpresaService { get; } = _empresaService;

        [HttpGet]
        public async Task<IActionResult> GetAllEmpresas()
        {
            try
            {
                var empresas = await EmpresaService.GetAllEmpresasAsync();

                if(empresas == null) return NoContent();

                return Ok(empresas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("NomeEmpresa/{nomeEmpresa}")]
        public async Task<IActionResult> GetEmpresasBYNome(string nomeEmpresa)
        {
            try
            {
                var empresas = await EmpresaService.GetEmpresasByNomeAsync(nomeEmpresa);

                if(empresas == null) return NoContent();

                return Ok(empresas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("EmpresaId/{empresaId}")]
        public async Task<IActionResult> GetEmpresaById(int empresaId)
        {
            try
            {
                var empresa = await EmpresaService.GetEmpresaByIdAsync(empresaId);

                if(empresa == null) return NoContent();

                return Ok(empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostEmpresa(EmpresaRequestDto model)
        {
            try
            {
                var empresa = await EmpresaService.AddEmpresaAsync(model);

                if(empresa == null) return NoContent();

                return Ok(empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutEmpresa(EmpresaRequestDto model)
        {
            try
            {
                var empresa = await EmpresaService.UpdateEmpresaAsync(model);

                if(empresa == null) return NotFound("Empresa não encontrada!");

                return Ok(empresa);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar empresa. Erro: {ex.Message}");
            }
        }
    }
}
