using GuardianLog.Domain;

namespace GuardianLog.Repo.Contratos;

public interface ICidadeRepository
{
   Task<Cidade[]> GetCidadesByEstadoIdAsync(int estadoId);
   Task<Cidade?> GetCidadeByCodIBGEAsync(int codIBGE);
   Task<Cidade[]> GetCidadesByNomeAsync(string nomeCidade);
}
