using System;
using GuardianLog.Application.Dtos;

namespace GuardianLog.Application.Contratos;

public interface IMotoristaService
{
    Task<MotoristaDto[]?> GetAllMotoristasAsync();
    Task<MotoristaDto[]?> GetMotoristasByNomeAsync(string nomeMotorista);
    Task<MotoristaDto?> GetMotoristaByIdAsync(int motoristaId);
    Task<bool> AddMotoristaAsync(MotoristaDto model);
    Task<MotoristaDto?> UpdateMotoristaAsync(MotoristaDto model);
    Task<bool> DeletemotoristaAsync(int motoristaId);
}
