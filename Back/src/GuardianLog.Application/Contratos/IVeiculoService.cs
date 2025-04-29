using GuardianLog.Application.Dtos;

namespace GuardianLog.Application.Contratos;

public interface IVeiculoService
{
   Task<VeiculoResponseDto?> AddVeiculoAsync(VeiculoRequestDto veiculoModel);
   Task<VeiculoResponseDto?> UpdateVeiculoAsync(VeiculoRequestDto veiculoNovo);
   Task<VeiculoResponseDto[]?> GetAllVeiculosAsync();
   Task<VeiculoResponseDto?> GetVeiculoByIdAsync(int veiculoId);
   Task<VeiculoResponseDto?> GetVeiculoByPlacaAsync(string placa);
}
