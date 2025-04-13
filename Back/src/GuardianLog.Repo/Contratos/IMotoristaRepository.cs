using GuardianLog.Domain;

namespace GuardianLog.Repo.Contratos;

public interface IMotoristaRepository
{
    Task<Motorista[]?> GetAllMotoristasAsync();
    Task<Motorista[]?> GetMotoristasByNomeAsync(string nomeMotorista);
    Task<Motorista?> GetMotoristaByIdAsync(int motoristaId);
    Task<Endereco> SalvarEnderecoAsync(Endereco endereco);
    Task<Contato> SalvarContatoAsync(Contato contato);
    Task<bool> DeleteMotoristaAsync(int motoristaId);
}
