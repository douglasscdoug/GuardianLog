using GuardianLog.Domain;
using GuardianLog.Repo.Contexts;
using GuardianLog.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GuardianLog.Repo;

public class EstadoRepository(Context _context) : IEstadoRepository
{
   public Context Context { get; } = _context;

   public async Task<Estado?> GetEstadoByIdAsync(int estadoId)
   {
      IQueryable<Estado> query = Context.Estados;

      query = query.Include(e => e.Cidades);

      query = query.AsNoTracking().Where(e => e.Id == estadoId);

      return await query.FirstOrDefaultAsync();
   }

   public async Task<Estado[]> GetEstadosBYPaisIdAsync(int paisId)
   {
      IQueryable<Estado> query = Context.Estados;

      query = query.AsNoTracking().OrderBy(e => e.NomeEstado).Where(e => e.IdPais == paisId);

      return await query.ToArrayAsync();
   }
}