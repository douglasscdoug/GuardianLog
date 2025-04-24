using System.Data.Common;
using GuardianLog.Domain;

namespace GuardianLog.Repo.Contratos;

public interface IEmpresaRepository
{
    Task<Empresa[]?> GetAllEmpresasAsync();
    Task<Empresa[]?> GetEmpresasByNomeAsync(string nomeEmpresa);
    Task<Empresa?> GetEmpresaByIdAsync(int empresaId);
    IQueryable<Empresa> QueryEmpresaById(int empresaId);
    Task<Endereco> SalvarEnderecoAsync(Endereco endereco);
    Task<Contato> SalvarContatoAsync(Contato contato);
    Task<Contato?> GetContatoById(int contatoId);
}
