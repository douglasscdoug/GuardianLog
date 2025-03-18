using GuardianLog.Application.Dtos;

namespace GuardianLog.Application.Contratos;

public interface IVeiculoService
{
   Task<bool> AddVeiculoAsync(VeiculoDto veiculoModel);
   Task<VeiculoDto?> UpdateVeiculoAsync(VeiculoDto veiculoNovo);
   Task<bool> DeleteVeiculoAsync(int veiculoId);
   Task<VeiculoDto[]?> GetAllVeiculosAsync();
   Task<VeiculoDto?> GetVeiculoByIdAsync(int veiculoId);
   Task<VeiculoDto?> GetVeiculoByPlacaAsync(string placa);
}
