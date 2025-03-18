namespace GuardianLog.Domain;

public class Veiculo
{
   public int Id { get; set; }
   public required string Placa { get; set; }
   public bool VeiculoInternacional { get; set; }
   public required TipoVeiculo TipoVeiculo { get; set; }
   public int IdTipoVeiculo { get; set; }
   public TipoCarreta ? TipoCarreta { get; set; }
   public int ? IdTipoCarreta { get; set; }
   public required string Chassi { get; set; }
   public required ModeloVeiculo ModeloVeiculo { get; set; }
   public int IdModeloVeiculo { get; set; }
   public int AnoFabricacao { get; set; }
   public required Cor Cor { get; set; }
   public int IdCor { get; set; }
   public required string Renavam { get; set; }
   public required Cidade Cidade { get; set; }
   public int IdCidade { get; set; }
   public required TipoVinculo TipoVinculo { get; set; }
   public int IdTipoVinculo { get; set; }
   public required TecnologiaRastreamento Tecnologia { get; set; }
   public int IdTecnologia { get; set; }
   public int IdEquipamento { get; set; }
   public DateTime DataCadastro { get; set; }
   public DateTime ? DataAlteracao { get; set; }
}
