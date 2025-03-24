using GuardianLog.Domain;

namespace GuardianLog.Repo.Contratos;

public interface ITipoCarretaRepository
{
   Task<TipoCarreta[]?> GetAllTiposCarretaAsync();
   Task<TipoCarreta?> GetTipoCarretaByIdAsync(int tpCarretaId);
}
