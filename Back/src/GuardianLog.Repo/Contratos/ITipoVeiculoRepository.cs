using System;
using GuardianLog.Domain;

namespace GuardianLog.Repo.Contratos;

public interface ITipoVeiculoRepository
{
   Task<TipoVeiculo[]?> GetAllTiposVeiculoAsync();
   Task<TipoVeiculo?> GetTipoVeiculoByIdAsync(int tpVeiculoId);
}
