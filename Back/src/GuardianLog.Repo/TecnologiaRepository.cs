using GuardianLog.Domain;
using GuardianLog.Repo.Contexts;
using GuardianLog.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GuardianLog.Repo;

public class TecnologiaRepository(Context _context) : ITecnologiaRepository
{
   public Context Context { get; } = _context;

   public async Task<TecnologiaRastreamento[]?> GetAllTecnologiasAsync()
   {
      IQueryable<TecnologiaRastreamento> query = Context.TecnologiasRastreamento;

      query = query.AsNoTracking().OrderBy(t => t.Nome);

      return await query.ToArrayAsync();
   }

   public async Task<TecnologiaRastreamento?> GetTecnologiaByIdAsync(int tecnologiaId)
   {
      IQueryable<TecnologiaRastreamento> query = Context.TecnologiasRastreamento;

      query = query.AsNoTracking().Where(t => t.Id == tecnologiaId);

      return await query.FirstOrDefaultAsync();
   }
}