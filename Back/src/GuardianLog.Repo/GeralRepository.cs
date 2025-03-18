using System;
using GuardianLog.Repo.Contexts;
using GuardianLog.Repo.Contratos;

namespace GuardianLog.Repo;

public class GeralRepository(Context _context) : IGeralRepository
{
   public Context Context { get; } = _context;
    public void Add<T>(T entity) where T : class
    {
        Context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        Context.Remove(entity);
    }

    public void Update<T>(T entity) where T : class
    {
        Context.Update(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await Context.SaveChangesAsync()) > 0;
    }
}
