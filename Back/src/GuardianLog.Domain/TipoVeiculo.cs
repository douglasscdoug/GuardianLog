namespace GuardianLog.Domain;

public class TipoVeiculo
{
   public int Id { get; set; }
   public required string Nome { get; set; }
   public List<Veiculo> Veiculos { get; set; } = [];
}
