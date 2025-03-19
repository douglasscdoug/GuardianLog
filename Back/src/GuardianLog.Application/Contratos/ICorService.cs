using GuardianLog.Application.Dtos;

namespace GuardianLog.Application.Contratos;

public interface ICorService
{
   Task<CorDto?> GetCorByIdAsync(int corId);
   Task<CorDto[]?> GetCoresByNomeAsync(string nomeCor);
   Task<CorDto[]?> GetAllCoresAsync();
   Task<bool> AddCorAsync(CorDto corModel);
   Task<CorDto?> UpdateCorAsync(CorDto corModel);
   Task<bool> DeleteCorAsync(int corId);
}
