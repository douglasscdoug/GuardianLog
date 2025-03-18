using GuardianLog.Application.Contratos;
using GuardianLog.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GuardianLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController(IVeiculoService _veiculoService) : ControllerBase
    {
        public IVeiculoService VeiculoService { get; } = _veiculoService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var veiculos = await VeiculoService.GetAllVeiculosAsync();

                if (veiculos == null) return NotFound("Nenhum veiculo encontrado!");

                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var veiculo = await VeiculoService.GetVeiculoByIdAsync(id);

                if (veiculo == null) return NotFound("Nenhum veículo encontrado!");

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("placa/{placa}")]
        public async Task<IActionResult> GetByPlaca(string placa)
        {
            try
            {
                var veiculo = await VeiculoService.GetVeiculoByPlaca(placa);

                if (veiculo == null) return NotFound("Nenhum veículo encontrado");

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Veiculo veiculo)
        {
            try
            {
                var result = await VeiculoService.AddVeiculoAsync(veiculo);

                if (!result) return BadRequest("Erro ao tentar cadastrar veículo!");

                return Ok("Veículo cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Veiculo veiculoNovo)
        {
            try
            {
                var veiculo = await VeiculoService.UpdateVeiculoAsync(veiculoNovo);

                if (veiculo == null) return NotFound($"Veículo Id: {veiculoNovo.Id} não encontrado!");

                return Ok($"Veículo Id: {veiculoNovo.Id} alterado com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await VeiculoService.DeleteVeiculoAsync(id);

                if (result) return Ok($"Veículo Id: {id} deletado com sucesso!");

                return BadRequest("Não foi possível deletar o veículo!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}