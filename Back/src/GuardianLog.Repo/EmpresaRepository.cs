using GuardianLog.Domain;
using GuardianLog.Repo.Contexts;
using GuardianLog.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GuardianLog.Repo;

public class EmpresaRepository(Context _context) : IEmpresaRepository
{
    public Context Context { get; } = _context;

    public async Task<Empresa[]?> GetAllEmpresasAsync()
    {
        IQueryable<Empresa> query = Context.Empresas;

        query = query.OrderBy(e => e.NomeFantasia);

        return await query.ToArrayAsync();
    }

    public async Task<Empresa[]?> GetEmpresasByNomeAsync(string nomeEmpresa)
    {
        IQueryable<Empresa> query = Context.Empresas;

        query = query.Where(e => e.NomeFantasia.ToLower().Contains(nomeEmpresa));

        return await query.ToArrayAsync();
    }

    public IQueryable<Empresa> GetEmpresaByIdQuery(int empresaId)
    {
        return Context.Empresas
            .AsNoTracking()
            .Include(e => e.Endereco!).ThenInclude(e => e.Cidade!).ThenInclude(c => c.Estado)
            .Include(e => e.Contato)
            .Where(e => e.Id == empresaId);
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

    public async Task<Contato?> GetContatoById(int contatoId)
    {
        return await Context.Contatos.FindAsync(contatoId);
    }
}
