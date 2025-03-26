namespace GuardianLog.Application.Dtos;

public class CEPDto
{
   public int Id { get; set; }
   public required string Cep { get; set; }
   public required string Logradouro { get; set; }
   public required string Localidade { get; set; }
   public int IdCidade { get; set; }
}
