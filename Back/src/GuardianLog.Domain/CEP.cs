namespace GuardianLog.Domain;

public class CEP
{
   public int Id { get; set; }
   public required string Cep { get; set; }
   public required string Logradouro { get; set; }
   public required string Localidade { get; set; }
   public required Cidade Cidade { get; set; }
   public int IdCidade { get; set; }
}
