using GuardianLog.Application.Dtos;

namespace GuardianLog.Application.Contratos;

public interface IMarcaVeiculoService
{
   Task<MarcaVeiculoDto[]?> GetAllMarcasVeiculosAsync();
   Task<MarcaVeiculoDto[]?> GetMarcasVeiculosByNomeAsync(string nomeMarca);
   Task<MarcaVeiculoDto?> GetMarcaVeiculoByIdAsync(int marcaId);
   Task<bool> AddMarcaVeiculoAsync(MarcaVeiculoDto marcaVeiculoModel);
   Task<MarcaVeiculoDto?> UpdateMarcaVeiculoAsync(MarcaVeiculoDto marcaVeiculoModel);
   Task<bool> DeleteMarcaVeiculoAsync(int marcaId);
}
