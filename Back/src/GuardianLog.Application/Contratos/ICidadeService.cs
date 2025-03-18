using GuardianLog.Application.Dtos;

namespace GuardianLog.Application.Contratos;

public interface ICidadeService
{
   Task<CidadeDto[]?> GetCidadesByEstadoIdAsync(int estadoId);
   Task<CidadeDto[]?> GetCidadesByNome(string nomeCidade);
   Task<CidadeDto?> GetCidadeByCodIBGEAsync(int codIBGE);
   Task<bool> AddCidadeAsync(CidadeDto cidade);
   Task<CidadeDto> UpdateCidadeAsync(CidadeDto cidadeModel);
   Task<bool> DeleteCidadeAsync(int cidadeId);
}
