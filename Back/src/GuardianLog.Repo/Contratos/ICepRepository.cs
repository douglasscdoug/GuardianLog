using System;
using GuardianLog.Domain;

namespace GuardianLog.Repo.Contratos;

public interface ICepRepository
{
    Task<CEP?> GetCepAsync(string numeroCep);
    Task<CEP?> GetCepByIdAsync(int cepId);
}
