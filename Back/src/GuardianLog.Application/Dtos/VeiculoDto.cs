using GuardianLog.Domain.Enum;

namespace GuardianLog.Application.Dtos;

public class VeiculoDto
{
   public int Id { get; set; }
   public required string Placa { get; set; }
   public bool VeiculoInternacional { get; set; }
   public int IdTipoVeiculo { get; set; }
   public int ? IdTipoCarreta { get; set; }
   public required string Chassi { get; set; }
   public int IdModeloVeiculo { get; set; }
   public int AnoFabricacao { get; set; }
   public int IdCor { get; set; }
   public required string Renavam { get; set; }
   public int IdCidade { get; set; }
   public int TipoVinculo { get; set; }
   public int IdTecnologia { get; set; }
   public int IdEquipamento { get; set; }
}
