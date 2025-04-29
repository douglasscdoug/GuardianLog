using GuardianLog.Application;
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

        //Endpoints Cor
        [HttpGet("Cores")]
        public async Task<IActionResult> GetAllCores()
        {
            try
            {
                var cores = await VeiculoService.GetAllCoresAsync();

                if (cores == null) return NoContent();

                return Ok(cores);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("Cores")]
        public async Task<IActionResult> SalvarCor(CorDto model)
        {
            try
            {
                var cor = await VeiculoService.SalvarCorAsync(model);

                if (cor == null) return NoContent();

                return Ok(cor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Marcas
        [HttpGet("Marcas")]
        public async Task<IActionResult> GetAllMarcas()
        {
            try
            {
                var marcas = await VeiculoService.GetAllMarcasVeiculosAsync();

                if(marcas == null) return NoContent();

                return Ok(marcas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("Marcas")]
        public async Task<IActionResult> SalvarMarca(MarcaVeiculoDto model)
        {
            try
            {
                var marca = await VeiculoService.SalvarMarcaVeiculoAsync(model);

                if(marca == null) return NoContent();

                return Ok(marca);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Modelos
        [HttpGet("ModelosByMarca/{marcaId}")]
        public async Task<IActionResult> GetModelosByMarcaId(int marcaId)
        {
            try
            {
                var modelos = await VeiculoService.GetModelosVeiculoByMarcaIdAsync(marcaId);

                if (modelos == null) return NoContent();

                return Ok(modelos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("Modelos")]
        public async Task<IActionResult> SalvarModelo(ModeloVeiculoDto model)
        {
            try
            {
                var modelo = await VeiculoService.SalvarModeloAsync(model);

                if(modelo == null) return NoContent();

                return Ok(modelo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Tecnologia
        [HttpGet("Tecnologias")]
        public async Task<IActionResult> GetAllTecnologias()
        {
            try
            {
                var tecnologias = await VeiculoService.GetAllTecnologiasAsync();

                if (tecnologias == null) return NoContent();

                return Ok(tecnologias);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("Tecnologias")]
        public async Task<IActionResult> SalvarTecnologia(TecnologiaRastreamentoDto model)
        {
            try
            {
                var tecnologia = await VeiculoService.SalvarTecnologiaAsync(model);

                if(tecnologia == null) return NoContent();

                return Ok(tecnologia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Tipo Carreta
        [HttpGet("TiposCarreta")]
        public async Task<IActionResult> GetTiposCarreta()
        {
            try
            {
                var tpsCarreta = await VeiculoService.GetAllTiposCarretaAsync();

                if(tpsCarreta == null) return NoContent();

                return Ok(tpsCarreta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("TiposCarreta")]
        public async Task<IActionResult> SalvarTipoCarreta(TipoCarretaDto model)
        {
            try
            {
                var tpCarreta = await VeiculoService.SalvarTipoCarretaAsync(model);

                if(tpCarreta == null) return NoContent();

                return Ok(tpCarreta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Tipo Veículo
        [HttpGet("TiposVeiculo")]
        public async Task<IActionResult> GetAllTiposVeiculo()
        {
            try
            {
                var tpsVeiculo = await VeiculoService.GetAllTiposVeiculoAsync();

                if (tpsVeiculo == null) return NoContent();

                return Ok(tpsVeiculo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("TiposVeiculo")]
        public async Task<IActionResult> SalvarTipoVeiculo(TipoVeiculoDto model)
        {
            try
            {
                var tpVeiculo = await VeiculoService.SalvarTipoVeiculoAsync(model);

                if (tpVeiculo == null) return NoContent();

                return Ok(tpVeiculo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}