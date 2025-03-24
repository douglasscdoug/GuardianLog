using GuardianLog.Application.Dtos;

namespace GuardianLog.Application.Contratos;

public interface ITipoCarretaService
{
   Task<TipoCarretaDto[]?> GetAllTiposCarretaAsync();
   Task<TipoCarretaDto?> GetTipoCarretaByIdAsync(int tpCarretaId);
   Task<bool> SalvarTipoCarretaAsync(TipoCarretaDto model);
}
