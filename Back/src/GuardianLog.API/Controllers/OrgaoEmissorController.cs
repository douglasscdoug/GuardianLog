using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuardianLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgaoEmissorController(IOrgaoEmissorService _orgaoService) : ControllerBase
    {
        public IOrgaoEmissorService OrgaoService { get; } = _orgaoService;

        [HttpGet]
        public async Task<IActionResult> GetAllOrgaos()
        {
            try
            {
                var orgaos = await OrgaoService.GetAllOrgaosEmissoresAsync();

                if(orgaos == null) return NoContent();

                return Ok(orgaos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("OrgaoId/{orgaoId}")]
        public async Task<IActionResult> GetOrgaoById(int orgaoId)
        {
            try
            {
                var orgao = await OrgaoService.GetOrgaoEmissorByIdAsync(orgaoId);

                if(orgao == null) return NoContent();

                return Ok(orgao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostOrgao(OrgaoEmissorDto model)
        {
            try
            {
                var orgao = await OrgaoService.SalvarOrgaoEmissorAsync(model);

                if(orgao != null) return Ok(orgao);

                return BadRequest("Erro ao tentar salvar orgão!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
