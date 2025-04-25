using System;
using GuardianLog.Domain;
using GuardianLog.Repo.Contexts;
using GuardianLog.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GuardianLog.Repo;

public class MotoristaRepository(Context _context) : IMotoristaRepository
{
    public Context Context { get; } = _context;

    public async Task<Motorista[]?> GetAllMotoristasAsync()
    {
        IQueryable<Motorista> query = Context.Motoristas;

        query = query.AsNoTracking().OrderBy(m => m.Nome);

        return await query.ToArrayAsync();
    }

    public async Task<Motorista[]?> GetMotoristasByNomeAsync(string nomeMotorista)
    {
        IQueryable<Motorista> query = Context.Motoristas;

        query = query.AsNoTracking().OrderBy(m => m.Nome).Where(m => m.Nome.ToLower().Contains(nomeMotorista.ToLower()));

        return await query.ToArrayAsync();
    }

    public async Task<Motorista?> GetMotoristaByIdAsync(int motoristaId)
    {
        IQueryable<Motorista> query = Context.Motoristas;

        query = query.AsNoTracking().Where(m => m.Id == motoristaId);

        return await query.FirstOrDefaultAsync();
    }

    public IQueryable<Motorista> QueryMotoristaById(int motoristaId)
    {
        return Context.Motoristas
            .AsNoTracking()
            .Include(m => m.Endereco!).ThenInclude(e => e.Cidade!).ThenInclude(c => c.Estado)
            .Include(m => m.Contato)
            .Where(m => m.Id == motoristaId);
    }

    public async Task<Endereco> SalvarEnderecoAsync(Endereco endereco)
    {
        Context.Add(endereco);
        await Context.SaveChangesAsync();
        return endereco;
    }

    public async Task<Contato> SalvarContatoAsync(Contato contato)
    {
        Context.Add(contato);
        await Context.SaveChangesAsync();
        return contato;
    }

    public async Task<bool> DeleteMotoristaAsync(int motoristaId)
    {
        var motorista = await Context.Motoristas.AsNoTracking().FirstOrDefaultAsync(m => m.Id == motoristaId);

        if (motorista == null)
        throw new Exception("Motorista não encontrado");

        var sql = "DELETE FROM Motoristas WHERE Id = {0}";

        var linhasAfetadas = await Context.Database.ExecuteSqlRawAsync(sql, motoristaId);

        return linhasAfetadas > 0;
    }
}
