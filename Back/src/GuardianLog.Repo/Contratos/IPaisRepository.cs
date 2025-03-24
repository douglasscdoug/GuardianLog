using GuardianLog.Domain;

namespace GuardianLog.Repo.Contratos;

public interface IPaisRepository
{
   Task<Pais[]?> GetAllPaisesAsync();
}
