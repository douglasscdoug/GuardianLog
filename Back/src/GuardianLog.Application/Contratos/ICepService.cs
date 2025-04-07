using GuardianLog.Application.Dtos;

namespace GuardianLog.Application.Contratos;

public interface ICepService
{
    Task<CEPResponseDto?> GetCepAsync(string numeroCep);
    Task<bool> AddCepAsync(CEPRequestDto model);
    Task<CEPResponseDto?> GetCepByIdAsync(int cepId);
}
