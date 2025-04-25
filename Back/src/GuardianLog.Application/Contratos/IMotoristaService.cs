using System;
using GuardianLog.Application.Dtos;

namespace GuardianLog.Application.Contratos;

public interface IMotoristaService
{
    Task<MotoristaResponseDto[]?> GetAllMotoristasAsync();
    Task<MotoristaResponseDto[]?> GetMotoristasByNomeAsync(string nomeMotorista);
    Task<MotoristaResponseDto?> GetMotoristaByIdAsync(int motoristaId);
    Task<bool> AddMotoristaAsync(MotoristaRequestDto model);
    Task<MotoristaRequestDto?> UpdateMotoristaAsync(MotoristaRequestDto model);
    Task<bool> DeletemotoristaAsync(int motoristaId);
}
