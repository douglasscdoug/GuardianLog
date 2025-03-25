using GuardianLog.Domain;
using GuardianLog.Repo.Contexts;
using GuardianLog.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GuardianLog.Repo;

public class TipoVeiculoRepository(Context _context) : ITipoVeiculoRepository
{
    public Context Context { get; } = _context;

    public async Task<TipoVeiculo[]?> GetAllTiposVeiculoAsync()
    {
        return await Context.TiposVeiculo.ToArrayAsync();
    }

    public async Task<TipoVeiculo?> GetTipoVeiculoByIdAsync(int tpVeiculoId)
    {
        IQueryable<TipoVeiculo> query = Context.TiposVeiculo;

        query = query.AsNoTracking().Where(t => t.Id == tpVeiculoId);

        return await query.FirstOrDefaultAsync();
    }
}
