namespace GuardianLog.Application.Dtos;

public class TecnologiaRastreamentoDto
{
   public int Id { get; set; }
   public required string Nome { get; set; }
   public DateTime DataCadastro { get; set; }
   public DateTime ? DataAlteracao { get; set; }
}
