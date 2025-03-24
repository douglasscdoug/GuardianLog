using GuardianLog.Domain;

namespace GuardianLog.Repo.Contratos;

public interface IModeloVeiculoRepository
{
   Task<ModeloVeiculo[]?> GetModelosVeiculoByMarcaIdAsync(int marcaId);
   Task<ModeloVeiculo?> GetModeloVeiculoByIdAsync(int modeloId);
}
