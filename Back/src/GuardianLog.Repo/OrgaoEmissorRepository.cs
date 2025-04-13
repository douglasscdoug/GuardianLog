using GuardianLog.Domain;
using GuardianLog.Repo.Contexts;
using GuardianLog.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GuardianLog.Repo;

public class OrgaoEmissorRepository(Context _context) : IOrgaoEmissorRepository
{
    public Context Context { get; } = _context;

    public async Task<OrgaoEmissor[]?> GetAllOrgaosEmissoresAsync()
    {
        IQueryable<OrgaoEmissor> query = Context.OrgaosEmissores;

        query = query.AsNoTracking().OrderBy(o => o.NomeInstituicao);

        return await query.ToArrayAsync();
    }

    public async Task<OrgaoEmissor?> GetOrgaoEmissorByIdAsync(int orgaoId)
    {
        IQueryable<OrgaoEmissor> query = Context.OrgaosEmissores;

        query = query.AsNoTracking().Where(o => o.Id == orgaoId);

        return await query.FirstOrDefaultAsync();
    }
}
