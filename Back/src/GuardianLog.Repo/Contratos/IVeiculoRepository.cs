using GuardianLog.Domain;

namespace GuardianLog.Repo.Contratos;

public interface IVeiculoRepository
{
   Task<Veiculo[]?> GetAllVeiculos();
   Task<Veiculo?> GetVeiculoById(int veiculoId);
   Task<Veiculo?> GetVeiculoByPlaca(string placa);
}
