using GuardianLog.Domain;

namespace GuardianLog.Repo.Contratos;

public interface ITecnologiaRepository
{
   Task<TecnologiaRastreamento[]?> GetAllTecnologiasAsync();
   Task<TecnologiaRastreamento?> GetTecnologiaByIdAsync(int tecnologiaId);
}
