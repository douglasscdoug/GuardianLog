namespace GuardianLog.Domain;

public class Cidade
{
   public int Id { get; set; }
   public int ? CodCidadeIBGE { get; set; }
   public required string NomeCidade { get; set; }
   public required Estado Estado { get; set; }
   public int IdEstado { get; set; }
   public List<Veiculo> Veiculos { get; set; } = [];
   public List<CEP> CEPs { get; set; } = [];
}
