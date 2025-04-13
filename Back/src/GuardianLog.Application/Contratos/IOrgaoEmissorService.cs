using GuardianLog.Application.Dtos;

namespace GuardianLog.Application.Contratos;

public interface IOrgaoEmissorService
{
    Task<OrgaoEmissorDto[]?> GetAllOrgaosEmissoresAsync();
    Task<OrgaoEmissorDto?> GetOrgaoEmissorByIdAsync(int orgaoId);
    Task<OrgaoEmissorDto?> SalvarOrgaoEmissorAsync(OrgaoEmissorDto model);
}
