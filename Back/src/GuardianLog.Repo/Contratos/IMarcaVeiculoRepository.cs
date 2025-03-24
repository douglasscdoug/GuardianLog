using GuardianLog.Domain;

namespace GuardianLog.Repo.Contratos;

public interface IMarcaVeiculoRepository
{
   Task<MarcaVeiculo[]> GetAllMarcasVeiculosAsync();
   Task<MarcaVeiculo[]> GetMarcasVeiculosByNomeAsync(string nomeMarca);
   Task<MarcaVeiculo?> GetMarcaVeiculoByIdAsync(int marcaId);
}
