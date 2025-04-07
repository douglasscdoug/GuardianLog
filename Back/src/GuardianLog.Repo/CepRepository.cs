using GuardianLog.Domain;
using GuardianLog.Repo.Contexts;
using GuardianLog.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GuardianLog.Repo;

public class CepRepository(Context _context) : ICepRepository
{
    public Context Context { get; } = _context;

    public async Task<CEP?> GetCepAsync(string numeroCep)
    {
        IQueryable<CEP> query = Context.CEPs;

        query = query.Include(c => c.Cidade);

        query = query.AsNoTracking().Where(c => c.Cep.Contains(numeroCep));

        return await query.FirstOrDefaultAsync();
    }

    public async Task<CEP?> GetCepByIdAsync(int cepId)
    {
        IQueryable<CEP> query = Context.CEPs;

        query = query.AsNoTracking().Where(c => c.Id == cepId);

        return await query.FirstOrDefaultAsync();
    }
}
