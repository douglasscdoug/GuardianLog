namespace GuardianLog.Application.Dtos;

public class ModeloVeiculoDto
{
   public int Id { get; set; }
   public required string NomeModelo { get; set; }
   public int IdMarcaVeiculo { get; set; }
   public DateTime DataCadastro { get; set; }
   public DateTime ? DataAlteracao { get; set; }
}
