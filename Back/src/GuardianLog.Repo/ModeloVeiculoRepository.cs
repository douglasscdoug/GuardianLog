using GuardianLog.Domain;
using GuardianLog.Repo.Contexts;
using GuardianLog.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GuardianLog.Repo;

public class ModeloVeiculoRepository(Context _context) : IModeloVeiculoRepository
{
    public Context Context { get; } = _context;

    public async Task<ModeloVeiculo[]?> GetModelosVeiculoByMarcaIdAsync(int marcaId)
    {
        IQueryable<ModeloVeiculo> query = Context.ModelosVeiculos;

        query = query.AsNoTracking().OrderBy(m => m.NomeModelo).Where(m => m.IdMarcaVeiculo == marcaId);

        return await query.ToArrayAsync();
    }

    public async Task<ModeloVeiculo?> GetModeloVeiculoByIdAsync(int modeloId)
    {
        IQueryable<ModeloVeiculo> query = Context.ModelosVeiculos;

        query = query.AsNoTracking().Where(m => m.Id == modeloId);

        return await query.FirstOrDefaultAsync();
    }
}
