using System;
using GuardianLog.Domain;

namespace GuardianLog.Repo.Contratos;

public interface ICorRepository
{
   Task<Cor[]?> GetCoresByNomeAsync(string nomeCor);
   Task<Cor[]?> GetAllCoresAsync();
   Task<Cor?> GetCorByIdAsync(int corId);
}
