using GuardianLog.Domain;
using GuardianLog.Repo.Contexts;
using GuardianLog.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GuardianLog.Repo;

public class VeiculoRepository(Context _context) : IVeiculoRepository
{
    public Context Context { get; } = _context;

    public async Task<Veiculo[]?> GetAllVeiculos()
    {
        IQueryable<Veiculo> query = Context.Veiculos
            .Include(v => v.Cor)
            .Include(v => v.TipoVinculo)
            .Include(v => v.ModeloVeiculo);

        return await query.ToArrayAsync();
    }

    public async Task<Veiculo?> GetVeiculoById(int veiculoId)
    {
        IQueryable<Veiculo> query = Context.Veiculos
            .Include(v => v.Cor)
            .Include(v => v.TipoVinculo)
            .Include(v => v.ModeloVeiculo);

        query = query.AsNoTracking().OrderBy(v => v.Id).Where(v => v.Id == veiculoId);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<Veiculo?> GetVeiculoByPlaca(string placa)
    {
        IQueryable<Veiculo> query = Context.Veiculos
            .Include(v => v.Cor)
            .Include(v => v.TipoVinculo)
            .Include(v => v.ModeloVeiculo);

        query = query.AsNoTracking().OrderBy(v => v.Id).Where(v => v.Placa.ToLower().Contains(placa.ToLower()));

        return await query.FirstOrDefaultAsync();
    }
}
