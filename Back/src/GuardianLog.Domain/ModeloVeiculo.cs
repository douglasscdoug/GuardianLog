namespace GuardianLog.Domain;

public class ModeloVeiculo
{
   public int Id { get; set; }
   public required string NomeModelo { get; set; }
   public required MarcaVeiculo MarcaVeiculo { get; set; }
   public int IdMarcaVeiculo { get; set; }
   public List<Veiculo> Veiculos { get; set; } = [];
}
