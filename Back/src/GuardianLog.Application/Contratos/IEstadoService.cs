using GuardianLog.Application.Dtos;

namespace GuardianLog.Application.Contratos;

public interface IEstadoService
{
   Task<EstadoDto[]?> GetEstadosBYPaisIdAsync(int paisId);
   Task<EstadoDto?> GetEstadoByIdAsync(int estadoId);
   Task<bool> AddEstadoAsync(EstadoDto estadoModel);
   Task<EstadoDto?> UpdateEstadoAsync(EstadoDto estadoModel);
   Task<bool> DeleteEstadoAsync(int estadoId);
}
