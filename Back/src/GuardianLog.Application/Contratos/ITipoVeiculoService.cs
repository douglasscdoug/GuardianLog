using GuardianLog.Application.Dtos;

namespace GuardianLog.Application.Contratos;

public interface ITipoVeiculoService
{
   Task<TipoVeiculoDto[]?> GetAllTiposVeiculoAsync();
   Task<TipoVeiculoDto?> GetTipoVeiculoByIdAsync(int tpVeiculoId);
   Task<bool> SalvarTipoVeiculoAsync(TipoVeiculoDto model);
}
