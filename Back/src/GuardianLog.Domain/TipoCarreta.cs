using System;

namespace GuardianLog.Domain;

public class TipoCarreta
{
   public int Id { get; set; }
   public required string Nome { get; set; }
   public List<Veiculo> Veiculos { get; set; } = [];
}
