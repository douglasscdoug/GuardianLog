using GuardianLog.Application.Dtos;

namespace GuardianLog.Application.Contratos;

public interface IModeloVeiculoService
{
   Task<ModeloVeiculoDto[]?> GetModelosVeiculoByMarcaIdAsync(int marcaId);
   Task<ModeloVeiculoDto?> GetModeloVeiculoByIdAsync(int modeloId);
   Task<bool> AddModeloAsync(ModeloVeiculoDto model);
   Task<ModeloVeiculoDto?> UpdateModeloAsync(ModeloVeiculoDto model);
   Task<bool> DeleteModeloAsync(int modeloId);
}
