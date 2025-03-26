namespace GuardianLog.Domain;

public class MarcaVeiculo
{
   public int Id { get; set; }
   public required string Nome { get; set; }
   public List<ModeloVeiculo> Modelos { get; set; } = [];
}
