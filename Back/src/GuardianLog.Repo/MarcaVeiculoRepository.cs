using GuardianLog.Domain;
using GuardianLog.Repo.Contexts;
using GuardianLog.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GuardianLog.Repo;

public class MarcaVeiculoRepository(Context _context) : IMarcaVeiculoRepository
{
   public Context Context { get; } = _context;

   public async Task<MarcaVeiculo[]> GetAllMarcasVeiculosAsync()
   {
      IQueryable<MarcaVeiculo> query = Context.MarcasVeiculos;

      query = query.AsNoTracking().OrderBy(m => m.Nome);

      return await query.ToArrayAsync();
   }

   public async Task<MarcaVeiculo[]> GetMarcasVeiculosByNomeAsync(string nomeMarca)
   {
      IQueryable<MarcaVeiculo> query = Context.MarcasVeiculos;

      query = query.AsNoTracking().OrderBy(m => m.Nome).Where(m => m.Nome.ToLower().Contains(nomeMarca.ToLower()));

      return await query.ToArrayAsync();
   }

   public async Task<MarcaVeiculo?> GetMarcaVeiculoByIdAsync(int marcaId)
   {
      IQueryable<MarcaVeiculo> query = Context.MarcasVeiculos;

      query = query.Include(m => m.Modelos);

      query = query.AsNoTracking().Where(m => m.Id == marcaId);

      return await query.FirstOrDefaultAsync();
   }
}