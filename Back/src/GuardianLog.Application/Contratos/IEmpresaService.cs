using GuardianLog.Application.Dtos;

namespace GuardianLog.Application.Contratos;

public interface IEmpresaService
{
    Task<EmpresaDto[]?> GetAllEmpresasAsync();
    Task<EmpresaDto[]?> GetEmpresasByNomeAsync(string nomeEmpresa);
    Task<EmpresaDto?> GetEmpresaByIdAsync(int empresaId);
    Task<bool> AddEmpresaAsync(EmpresaRequestDto model);
    Task<EmpresaDto?> UpdateEmpresaAsync(EmpresaRequestDto model);
}
