using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
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
                var veiculo = await VeiculoService.GetVeiculoByPlacaAsync(placa);

                if (veiculo == null) return NotFound("Nenhum veículo encontrado");

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(VeiculoRequestDto model)
        {
            try
            {
                var veiculo = await VeiculoService.AddVeiculoAsync(model);

                if (veiculo == null) return NoContent();

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(VeiculoRequestDto model)
        {
            try
            {
                var veiculo = await VeiculoService.UpdateVeiculoAsync(model);

                if (veiculo == null) return NotFound($"Veículo Id: {model.Id} não encontrado!");

                return Ok($"Veículo Id: {model.Id} alterado com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}