using GuardianLog.Application.Dtos;

namespace GuardianLog.Application.Contratos;

public interface IPaisService
{
   Task<PaisDto[]?> GetAllPaisesAsync();
   Task<bool> AddPaisAsync(PaisDto paisModel);
}
