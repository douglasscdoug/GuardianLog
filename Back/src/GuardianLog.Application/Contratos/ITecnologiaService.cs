using GuardianLog.Application.Dtos;

namespace GuardianLog.Application.Contratos;

public interface ITecnologiaService
{
   Task<TecnologiaRastreamentoDto[]?> GetAllTecnologiasAsync();
   Task<TecnologiaRastreamentoDto?> GetTecnologiaByIdAsync(int tecnologiaId);
   Task<bool> AddTecnologiaAsync(TecnologiaRastreamentoDto model);
   Task<TecnologiaRastreamentoDto?> UpdateTecnologiaAsync(TecnologiaRastreamentoDto model);
}
