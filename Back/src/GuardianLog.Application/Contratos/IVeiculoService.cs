using GuardianLog.Application.Dtos;

namespace GuardianLog.Application.Contratos;

public interface IVeiculoService
{
   Task<VeiculoResponseDto?> AddVeiculoAsync(VeiculoRequestDto veiculoModel);
   Task<VeiculoResponseDto?> UpdateVeiculoAsync(VeiculoRequestDto veiculoNovo);
   Task<VeiculoResponseDto[]?> GetAllVeiculosAsync();
   Task<VeiculoResponseDto?> GetVeiculoByIdAsync(int veiculoId);
   Task<VeiculoResponseDto?> GetVeiculoByPlacaAsync(string placa);

   //Cores
   Task<CorDto[]?> GetAllCoresAsync();
   Task<CorDto?> SalvarCorAsync(CorDto model);

   //Marcas
   Task<MarcaVeiculoDto[]?> GetAllMarcasVeiculosAsync();
   Task<MarcaVeiculoDto?> SalvarMarcaVeiculoAsync(MarcaVeiculoDto model);

   //Modelos
   Task<ModeloVeiculoDto[]?> GetModelosVeiculoByMarcaIdAsync(int marcaId);
   Task<ModeloVeiculoDto?> SalvarModeloAsync(ModeloVeiculoDto model);

   //Tecnologias
   Task<TecnologiaRastreamentoDto[]?> GetAllTecnologiasAsync();
   Task<TecnologiaRastreamentoDto?> SalvarTecnologiaAsync(TecnologiaRastreamentoDto model);

   //Tipo Carreta
   Task<TipoCarretaDto[]?> GetAllTiposCarretaAsync();
   Task<TipoCarretaDto?> SalvarTipoCarretaAsync(TipoCarretaDto model);

   //Tipo Veiculo
   Task<TipoVeiculoDto[]?> GetAllTiposVeiculoAsync();
   Task<TipoVeiculoDto?> SalvarTipoVeiculoAsync(TipoVeiculoDto model);
}
