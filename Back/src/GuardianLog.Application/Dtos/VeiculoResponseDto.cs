namespace GuardianLog.Application.Dtos;

public class VeiculoResponseDto
{
    public int Id { get; set; }
    public required string Placa { get; set; }
    public bool VeiculoInternacional { get; set; }
    public required TipoVeiculoDto TipoVeiculo { get; set; }
    public int IdTipoVeiculo { get; set; }
    public TipoCarretaDto? TipoCarreta { get; set; }
    public int? IdTipoCarreta { get; set; }
    public required string Chassi { get; set; }
    public required ModeloVeiculoDto ModeloVeiculo { get; set; }
    public int IdModeloVeiculo { get; set; }
    public int AnoFabricacao { get; set; }
    public required CorDto Cor { get; set; }
    public int IdCor { get; set; }
    public required string Renavam { get; set; }
    public int TipoVinculo { get; set; }
    public required TecnologiaRastreamentoDto Tecnologia { get; set; }
    public int IdTecnologia { get; set; }
    public int IdEquipamento { get; set; }
}
