using GuardianLog.Domain;

namespace GuardianLog.Application.Contratos;

public interface IVeiculoService
{
   Task<bool> AddVeiculoAsync(Veiculo veiculo);
   Task<Veiculo?> UpdateVeiculoAsync(Veiculo veiculoNovo);
   Task<bool> DeleteVeiculoAsync(int veiculoId);
   Task<Veiculo[]?> GetAllVeiculosAsync();
   Task<Veiculo?> GetVeiculoByIdAsync(int veiculoId);
   Task<Veiculo?> GetVeiculoByPlaca(string placa);
}
