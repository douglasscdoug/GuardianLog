using System;
using GuardianLog.Application.Dtos;

namespace GuardianLog.Application.Contratos;

public interface IMotoristaService
{
    Task<MotoristaResponseDto[]?> GetAllMotoristasAsync();
    Task<MotoristaResponseDto[]?> GetMotoristasByNomeAsync(string nomeMotorista);
    Task<MotoristaResponseDto?> GetMotoristaByIdAsync(int motoristaId);
    Task<MotoristaResponseDto?> AddMotoristaAsync(MotoristaRequestDto model);
    Task<MotoristaResponseDto?> UpdateMotoristaAsync(MotoristaRequestDto model);
    Task<bool> DeletemotoristaAsync(int motoristaId);
}
