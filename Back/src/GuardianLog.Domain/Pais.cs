namespace GuardianLog.Domain;

public class Pais
{
   public int Id { get; set; }
   public required string Nome { get; set; }
   public required string Nacionalidade { get; set; }
   public List<Estado> Estados { get; set; } = [];
}
