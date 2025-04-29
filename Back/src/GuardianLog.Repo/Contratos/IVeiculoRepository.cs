using GuardianLog.Domain;

namespace GuardianLog.Repo.Contratos;

public interface IVeiculoRepository
{
   Task<Veiculo[]?> GetAllVeiculos();
   Task<Veiculo?> GetVeiculoById(int veiculoId);
   Task<Veiculo?> GetVeiculoByPlaca(string placa);

   //Cor
   Task<Cor[]?> GetAllCoresAsync();
   Task<Cor?> GetCorByIdAsync(int corId);

   //Marca
   Task<MarcaVeiculo[]> GetAllMarcasVeiculosAsync();
   Task<MarcaVeiculo?> GetMarcaVeiculoByIdAsync(int marcaId);

   //Modelo
   Task<ModeloVeiculo[]?> GetModelosVeiculoByMarcaIdAsync(int marcaId);
   Task<ModeloVeiculo?> GetModeloVeiculoByIdAsync(int modeloId);

   //Tecnologia
   Task<TecnologiaRastreamento[]?> GetAllTecnologiasAsync();
   Task<TecnologiaRastreamento?> GetTecnologiaByIdAsync(int tecnologiaId);

   //Tipo Carreta
   Task<TipoCarreta[]?> GetAllTiposCarretaAsync();
   Task<TipoCarreta?> GetTipoCarretaByIdAsync(int tpCarretaId);

   //Tipo Veiculo
   Task<TipoVeiculo[]?> GetAllTiposVeiculoAsync();
   Task<TipoVeiculo?> GetTipoVeiculoByIdAsync(int tpVeiculoId);
}
