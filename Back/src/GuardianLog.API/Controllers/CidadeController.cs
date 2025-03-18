using GuardianLog.Application;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuardianLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController(ICidadeService _cidadeService) : ControllerBase
    {
        public ICidadeService CidadeService { get; } = _cidadeService;

        [HttpGet("estadoId/{estadoId}")]
        public async Task<IActionResult> GetByEstadoId(int estadoId)
        {
            try
            {
                var cidades = await CidadeService.GetCidadesByEstadoIdAsync(estadoId);

                if (cidades == null) return NoContent();

                return Ok(cidades);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("nome/{nomeCidade}")]
        public async Task<IActionResult> GetByNome(string nomeCidade)
        {
            try
            {
                var cidades = await CidadeService.GetCidadesByNome(nomeCidade);

                if (cidades == null) return NoContent();

                return Ok(cidades);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("codIBGE/{codIBGE}")]
        public async Task<IActionResult> GetByCodIBGE(int codIBGE)
        {
            try
            {
                var cidade = await CidadeService.GetCidadeByCodIBGEAsync(codIBGE);

                if(cidade == null) return NoContent();

                return Ok(cidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CidadeDto cidade)
        {
            try
            {
                var result = await CidadeService.AddCidadeAsync(cidade);

                if(!result) return BadRequest("Erro ao tentar cadastrar a cidade!");

                return Ok("Cidade cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(CidadeDto cidadeModel)
        {
            try
            {
                var cidade = await CidadeService.UpdateCidadeAsync(cidadeModel);

                if(cidade == null) return NotFound("Cidade não encontrada");

                return Ok(cidade);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{cidadeId}")]
        public async Task<IActionResult> Delete(int cidadeId)
        {
            try
            {
                var result = await CidadeService.DeleteCidadeAsync(cidadeId);

                if(result) return Ok("Cidade deletada com sucesso!");

                return BadRequest("Erro ao tentar deletar a cidade");
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}