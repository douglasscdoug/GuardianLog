using GuardianLog.Domain;

namespace GuardianLog.Repo.Contratos;

public interface IEstadoRepository
{
   Task<Estado[]> GetEstadosBYPaisIdAsync(int paisId);
   Task<Estado?> GetEstadoByIdAsync(int estadoId);
}
