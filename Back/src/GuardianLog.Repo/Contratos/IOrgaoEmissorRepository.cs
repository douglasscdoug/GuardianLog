using GuardianLog.Domain;

namespace GuardianLog.Repo.Contratos;

public interface IOrgaoEmissorRepository
{
    Task<OrgaoEmissor[]?> GetAllOrgaosEmissoresAsync();
    Task<OrgaoEmissor?> GetOrgaoEmissorByIdAsync(int orgaoId);
}
