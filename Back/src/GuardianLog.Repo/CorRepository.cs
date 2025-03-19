using GuardianLog.Domain;
using GuardianLog.Repo.Contexts;
using GuardianLog.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GuardianLog.Repo;

public class CorRepository(Context _context) : ICorRepository
{
   public Context Context { get; } = _context;

   public async Task<Cor[]?> GetAllCoresAsync()
   {
      IQueryable<Cor> query = Context.Cores;

      query = query.AsNoTracking().OrderBy(c => c.Nome);

      return await query.ToArrayAsync();
   }

   public async Task<Cor?> GetCorByIdAsync(int corId)
   {
      IQueryable<Cor> query = Context.Cores;

      query = query.AsNoTracking().OrderBy(c => c.Nome).Where(c => c.Id == corId);

      return await query.FirstOrDefaultAsync();
   }

   public async Task<Cor[]?> GetCoresByNomeAsync(string nomeCor)
   {
      IQueryable<Cor> query = Context.Cores;

      query = query.AsNoTracking().OrderBy(c => c.Nome).Where(c => c.Nome.ToLower().Contains(nomeCor.ToLower()));

      return await query.ToArrayAsync();
   }
}