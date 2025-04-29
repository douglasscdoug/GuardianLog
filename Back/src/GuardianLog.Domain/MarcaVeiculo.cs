using System.Text.Json.Serialization;

namespace GuardianLog.Domain;

public class MarcaVeiculo
{
   public int Id { get; set; }
   public required string Nome { get; set; }

   [JsonIgnore]
   public List<ModeloVeiculo> Modelos { get; set; } = [];
}
