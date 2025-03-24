using System;
using GuardianLog.Domain;
using GuardianLog.Repo.Contexts;
using GuardianLog.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GuardianLog.Repo;

public class PaisRepository(Context _context) : IPaisRepository
{
    public Context Context { get; } = _context;

    public async Task<Pais[]?> GetAllPaisesAsync()
    {
        IQueryable<Pais> query = Context.Paises;

        query = query.Include(p => p.Estados);

        query = query.AsNoTracking().OrderBy(p => p.Nome);

        return await query.ToArrayAsync();
    }
}
