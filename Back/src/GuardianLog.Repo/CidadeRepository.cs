using GuardianLog.Domain;
using GuardianLog.Repo.Contexts;
using GuardianLog.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GuardianLog.Repo;

public class CidadeRepository(Context _context) : ICidadeRepository
{
   public Context Context { get; } = _context;

   public async Task<Cidade[]> GetCidadesByEstadoIdAsync(int estadoId)
   {
      IQueryable<Cidade> query = Context.Cidades;

      query = query.AsNoTracking().Where(c => c.IdEstado == estadoId);

      return await query.ToArrayAsync();
   }

   public async Task<Cidade?> GetCidadeByCodIBGEAsync(int codIBGE)
   {
      IQueryable<Cidade> query = Context.Cidades;

      query = query.AsNoTracking().Where(c => c.CodCidadeIBGE == codIBGE);

      return await query.FirstOrDefaultAsync();
   }

   public async Task<Cidade[]> GetCidadesByNomeAsync(string nomeCidade)
   {
      IQueryable<Cidade> query = Context.Cidades;

      query = query.AsNoTracking().Where(c => c.NomeCidade.ToLower().Contains(nomeCidade.ToLower()));

      query = query.Include(c => c.Estado);

      return await query.ToArrayAsync();
   }
}
