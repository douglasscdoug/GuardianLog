using System;
using GuardianLog.Domain;
using GuardianLog.Repo.Contexts;
using GuardianLog.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GuardianLog.Repo;

public class TipoCarretaRepository(Context _context) : ITipoCarretaRepository
{
    public Context Context { get; } = _context;

    public async Task<TipoCarreta[]?> GetAllTiposCarretaAsync()
    {
        IQueryable<TipoCarreta> query = Context.TiposCarreta;

        query = query.AsNoTracking().OrderBy(t => t.Nome);

        return await query.ToArrayAsync();
    }

    public async Task<TipoCarreta?> GetTipoCarretaByIdAsync(int tpCarretaId)
    {
        IQueryable<TipoCarreta> query = Context.TiposCarreta;

        query = query.AsNoTracking().Where(t => t.Id == tpCarretaId);

        return await query.FirstOrDefaultAsync();
    }
}
